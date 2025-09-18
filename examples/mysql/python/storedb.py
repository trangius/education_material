# ---- 0. Importera nödvändiga bibliotek  ----
import mysql.connector # för databaskoppling
import matplotlib.pyplot as plt # för diagram

# ---- 1. Konfiguration för databaskoppling ----
DB_HOST = "localhost" # server
DB_PORT = 1234                  # port
DB_USER = "username"            # användarnamn
DB_PASS = "password"       # lösenord
DB_NAME = "clothingstore"        # databasenamn

# ---- 2. Koppla upp mot databasen ----
con = mysql.connector.connect(
    host=DB_HOST,
    port=DB_PORT,
    user=DB_USER,
    password=DB_PASS,
    database=DB_NAME,
    charset="utf8mb4",collation="utf8mb4_general_ci" # MariaDB/MySQL teckenuppsättning
)

# ---- 3. Skapa en cursor och kör en query ----

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
cur = con.cursor()
cur.execute(sql) # kör frågan

# ---- 4. Hämta resultat och skriv ut i en loop med print ----
# lägg också till i en lista för att kunna rita diagrammet senare
months = []
revenues = []

print("=== Revenue per month ===")


# fetchall() hämtar alla rader i resultatet och ger en lista av tuples, t.ex:
# [('2023-01', 1500.00), ('2023-02', 1750.50), ('2023-03', 1600.75), ...]
#
# för varje sånt element (med tuples) så skapar vi två variabler
# month och revenue, som vi sen kan använda i loopen
for (month, revenue) in cur.fetchall():
    print(month, "->", revenue) # print() behövs såklart inte om man bara vill ha plot
    months.append(month)
    revenues.append(revenue)

# ---- 5. Stäng kopplingen mot databasen ----
cur.close()
con.close()

# ---- 6. Rita diagrammet med pyplot ----
# osäker på hur pyplot fungerar? Kolla dessa exempel:
plt.bar(months, revenues)
plt.xticks(rotation=45, ha="right")
plt.title("Revenue per month")
plt.ylabel("Revenue")
plt.tight_layout()
plt.show()
