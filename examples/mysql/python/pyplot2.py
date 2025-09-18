import matplotlib.pyplot as plt

categories = ["Apelsin", "Banan", "Äpple"]
sales = [10, 25, 17]

plt.bar(categories, sales)    # stapeldiagram
plt.title("Frukter sålda")
plt.ylabel("Antal")
plt.show()

