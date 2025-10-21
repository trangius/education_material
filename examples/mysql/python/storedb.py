# ---- 0. Importera nödvändiga bibliotek  ----
import mysql.connector # för databaskoppling
import matplotlib.pyplot as plt # för diagram


# ---- 1. Koppla upp mot databasen ----

connection = mysql.connector.connect(
    host="localhost",
    port=3306,
    user="user",
    password="password",
    database="storedb", 
    charset="utf8mb4",collation="utf8mb4_general_ci" # MariaDB/MySQL teckenuppsättning
)
cur = connection.cursor(dictionary=True)

# ---- 2. Skapa en cursor och kör en query ----

# tre citattecken för att kunna skriva över flera rader, här skapar vi en
# query som sträcker över flera rader:
sql = """
SELECT DATE_FORMAT(o.CreatedDate, '%Y-%m') AS Month,
       SUM(p2o.Quantity * p2o.UnitPrice) AS Revenue
FROM COrder o
JOIN ProductToOrder p2o ON o.Id = p2o.OrderId
GROUP BY DATE_FORMAT(o.CreatedDate, '%Y-%m')
ORDER BY Month;
"""

# skapa en cursor, en cursor används för att köra queries
# och hämta resultat ur databasen
cur.execute(sql) # kör frågan

# ---- 3. Hämta resultat och skriv ut i en loop med print ----
# lägg också till i en lista för att kunna rita diagrammet senare
months = []
revenues = []

print("=== Revenue per month ===")

# fetchall() hämtar alla rader i resultatet och ger en lista av dictionaries, t.ex:
# [{'Month': '2023-01', 'Revenue': 1500.00},
#  {'Month': '2023-02', 'Revenue': 1750.50},
#  {'Month': '2023-03', 'Revenue': 1600.75}, ...]
#
# för varje sånt element (dictionary) så kan vi läsa ut värdena med nycklarna
# 'Month' och 'Revenue' i loopen
for row in cur.fetchall():
    print(row["Month"], "->", row["Revenue"]) # print() behövs såklart inte om man bara vill ha plot
    months.append(row["Month"])
    revenues.append(row["Revenue"])

# ---- 4. Stäng kopplingen mot databasen ----
cur.close()
connection.close()

# ---- 5. Rita diagrammet med pyplot ----
plt.bar(months, revenues)
plt.xticks(rotation=45, ha="right")
plt.title("Revenue per month")
plt.ylabel("Revenue")
plt.tight_layout()
plt.show()

# osäker på hur pyplot fungerar? Kolla dessa exempel:
# https://github.com/trangius/education_material/blob/main/examples/mysql/python/pyplot1.py
# https://github.com/trangius/education_material/blob/main/examples/mysql/python/pyplot2.py
# https://github.com/trangius/education_material/blob/main/examples/mysql/python/pyplot3.py

