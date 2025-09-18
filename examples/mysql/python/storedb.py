import mysql.connector # för databaskoppling
import matplotlib.pyplot as plt # för diagram

# ---- Konfiguration för databaskoppling ----
DB_HOST = "localhost" # server
DB_PORT = 1234                  # port
DB_USER = "username"            # användarnamn
DB_PASS = "password"       # lösenord
DB_NAME = "clothingstore"        # databasenamn

# ---- Koppla upp mot databasen ----
con = mysql.connector.connect(
    host=DB_HOST,
    port=DB_PORT,
    user=DB_USER,
    password=DB_PASS,
    database=DB_NAME,
    charset="utf8mb4",collation="utf8mb4_general_ci" # MariaDB/MySQL teckenuppsättning
)

# ---- Skapa en cursor och kör en query ----

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

# ---- Hämta resultat och skriv ut i en loop med print ----
# lägg också till i en lista för att kunna rita diagrammet senare
months = []
revenues = []

print("=== Revenue per month ===")
for (month, revenue) in cur.fetchall():
    # Varje rad är en tuple (Month, Revenue)
    print(month, "->", revenue)
    months.append(month)
    revenues.append(revenue)

# ---- Stäng kopplingen mot databasen ----
cur.close()
con.close()

# ---- Rita diagrammet med pyplot ----
plt.bar(months, revenues)
plt.xticks(rotation=45, ha="right")
plt.title("Revenue per month")
plt.ylabel("Revenue")
plt.tight_layout()
plt.show()