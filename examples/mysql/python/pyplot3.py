import matplotlib.pyplot as plt

x = [5,  7,  8,  7,  6,   9,  5,   6,  7,  8]
y = [99, 86, 87, 88, 100, 86, 103, 87, 94, 78]

plt.scatter(x, y)             # punktdiagram
plt.title("Punktdiagram")
plt.xlabel("X")
plt.ylabel("Y")
plt.show()

