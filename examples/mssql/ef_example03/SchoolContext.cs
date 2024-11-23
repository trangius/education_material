    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ange din anslutningssträng här
        optionsBuilder.UseSqlServer("DinAnslutningssträngHär");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definiera relationer och begränsningar om det behövs
    }
}
