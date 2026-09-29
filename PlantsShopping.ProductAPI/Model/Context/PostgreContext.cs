using Microsoft.EntityFrameworkCore;

namespace PlantsShopping.ProductAPI.Model.Context
{
    public class PostgreContext : DbContext
    {
        public PostgreContext() { }
        public PostgreContext(DbContextOptions<PostgreContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 2,
                Name = "Monstera Deliciosa (Costela-de-Adão)",
                Price = new decimal(89.90),
                Description = "Planta de interior muito popular, conhecida por suas folhas grandes e recortadas.<br/>Ideal para ambientes internos com luz indireta.<br/>Fácil de cuidar e excelente para dar um toque tropical na decoração da sua casa ou escritório.",
                ImageUrl = "https://images.unsplash.com/photo-1614594975525-e45190c55d0b?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta de Interior"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 3,
                Name = "Samambaia Americana",
                Price = new decimal(49.99),
                Description = "Clássica planta pendente com folhagem verde intensa e delicada.<br/>Gosta de ambientes úmidos e meia-sombra, sendo perfeita para varandas e áreas internas arejadas.<br/>Traga frescor e movimento para o seu espaço.",
                ImageUrl = "https://images.unsplash.com/photo-1512428559087-560fa5ceab42?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta Pendente"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 4,
                Name = "Antúrio Vermelho",
                Price = new decimal(59.90),
                Description = "Conhecida por suas flores vistosas em formato de coração e brilho característico.<br/>Excelente para decorar salas e escritórios com muita elegância e cor.<br/>Prefere luz indireta e solo levemente úmido.",
                ImageUrl = "https://images.unsplash.com/photo-1599598425947-4402690ff3c7?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta com Flor"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 5,
                Name = "Suculenta Echeveria em Vaso Mini",
                Price = new decimal(24.99),
                Description = "Planta suculenta de pequeno porte, perfeita para mesas de trabalho e prateleiras.<br/>Requer pouca rega e bastante luminosidade.<br/>Um toque de verde delicado e de baixa manutenção para o seu dia a dia.",
                ImageUrl = "https://images.unsplash.com/photo-1509423350716-97f9360b4e09?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Suculentas"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 6,
                Name = "Ficus Lyrata (Figueira-Bate-Folha)",
                Price = new decimal(149.90),
                Description = "Árvore de interior com folhas grandes, brilhantes e em formato de violino.<br/>Muito elegante, destaca-se em salas de estar amplas e varandas cobertas.<br/>Necessita de regas moderadas e luz solar indireta abundante.",
                ImageUrl = "https://images.unsplash.com/photo-1545241047-6083a3684587?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta de Interior"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 7,
                Name = "Lírio-da-Paz",
                Price = new decimal(54.90),
                Description = "Famosa por suas elegantes flores brancas e folhagem verde escura brilhante.<br/>Excelente purificadora de ar para ambientes internos.<br/>Adapta-se muito bem a locais com menor incidência de luz solar direta.",
                ImageUrl = "https://images.unsplash.com/photo-1593482834249-f0896792376d?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta com Flor"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 8,
                Name = "Cacto San Pedro",
                Price = new decimal(69.90),
                Description = "Cacto ornamental de crescimento erguido e marcante, ideal para projetos paisagísticos e decorações modernas.<br/>Extremamente resistente e de baixíssima manutenção.<br/>Exige sol pleno ou luz direta intensa.",
                ImageUrl = "https://images.unsplash.com/photo-1509205477838-a534e43a849f?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Cactos"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 9,
                Name = "Calathea Medallion (Planta-Pavão)",
                Price = new decimal(79.90),
                Description = "Surpreende pelos padrões geométricos únicos e tons de roxo na parte inferior de suas folhas.<br/>Gosta de ambientes úmidos, sombra parcial e solo leve.<br/>Um verdadeiro espetáculo de cores naturais para dentro de casa.",
                ImageUrl = "https://images.unsplash.com/photo-1606856540909-6af86992d9d8?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta de Interior"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 10,
                Name = "Jiboia Verde (Epipremnum aureum)",
                Price = new decimal(49.99),
                Description = "Planta trepadeira resistente, ideal para cultivo em prateleiras altas ou suportes suspensos.<br/>Seus ramos pendentes criam um efeito cascata belíssimo.<br/>Extremamente adaptável a diferentes condições de luz interna.",
                ImageUrl = "https://images.unsplash.com/photo-1598880940371-c756e015ba45?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta Pendente"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 11,
                Name = "Yucca Elephantipes (Yuca)",
                Price = new decimal(119.90),
                Description = "Planta arbustiva de visual escultural e tronco robusto.<br/>Ótima opção para cantos de salas e áreas externas iluminadas.<br/>Resistente a períodos curtos de seca.",
                ImageUrl = "https://images.unsplash.com/photo-1525498128493-380d1990a112?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta de Interior"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 12,
                Name = "Maranta Leuconeura (Planta-Oração)",
                Price = new decimal(45.90),
                Description = "Possui folhas marcantes com nervuras avermelhadas que se fecham à noite, como em sinal de prece.<br/>Perfeita para mesas de centro e aparadores com meia-luz.<br/>Adora umidade e carinho.",
                ImageUrl = "https://images.unsplash.com/photo-1520302450370-7a2113d5b86f?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta de Interior"
            });
            modelBuilder.Entity<Plant>().HasData(new Plant
            {
                Id = 13,
                Name = "Zamioculca em Vaso",
                Price = new decimal(79.99),
                Description = "Conhecida por sua alta resistência, a zamioculca sobrevive bem em ambientes com pouca luz e regas esporádicas.<br/>Folhas verdes escuras com brilho natural impressionante.<br/>A planta perfeita para quem costuma esquecer de regar.",
                ImageUrl = "https://images.unsplash.com/photo-1632834379967-a0ce5cb2544e?q=80&w=1000&auto=format&fit=crop",
                CategoryName = "Planta de Interior"
            });
        }
    }
}