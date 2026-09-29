using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlantsShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPlantDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "plant",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "Planta de Interior", "Planta de interior muito popular, conhecida por suas folhas grandes e recortadas.<br/>Ideal para ambientes internos com luz indireta.<br/>Fácil de cuidar e excelente para dar um toque tropical na decoração da sua casa ou escritório.", "https://images.unsplash.com/photo-1614594975525-e45190c55d0b?q=80&w=1000&auto=format&fit=crop", "Monstera Deliciosa (Costela-de-Adão)", 89.9m },
                    { 3L, "Planta Pendente", "Clássica planta pendente com folhagem verde intensa e delicada.<br/>Gosta de ambientes úmidos e meia-sombra, sendo perfeita para varandas e áreas internas arejadas.<br/>Traga frescor e movimento para o seu espaço.", "https://images.unsplash.com/photo-1512428559087-560fa5ceab42?q=80&w=1000&auto=format&fit=crop", "Samambaia Americana", 49.99m },
                    { 4L, "Planta com Flor", "Conhecida por suas flores vistosas em formato de coração e brilho característico.<br/>Excelente para decorar salas e escritórios com muita elegância e cor.<br/>Prefere luz indireta e solo levemente úmido.", "https://images.unsplash.com/photo-1599598425947-4402690ff3c7?q=80&w=1000&auto=format&fit=crop", "Antúrio Vermelho", 59.9m },
                    { 5L, "Suculentas", "Planta suculenta de pequeno porte, perfeita para mesas de trabalho e prateleiras.<br/>Requer pouca rega e bastante luminosidade.<br/>Um toque de verde delicado e de baixa manutenção para o seu dia a dia.", "https://images.unsplash.com/photo-1509423350716-97f9360b4e09?q=80&w=1000&auto=format&fit=crop", "Suculenta Echeveria em Vaso Mini", 24.99m },
                    { 6L, "Planta de Interior", "Árvore de interior com folhas grandes, brilhantes e em formato de violino.<br/>Muito elegante, destaca-se em salas de estar amplas e varandas cobertas.<br/>Necessita de regas moderadas e luz solar indireta abundante.", "https://images.unsplash.com/photo-1545241047-6083a3684587?q=80&w=1000&auto=format&fit=crop", "Ficus Lyrata (Figueira-Bate-Folha)", 149.9m },
                    { 7L, "Planta com Flor", "Famosa por suas elegantes flores brancas e folhagem verde escura brilhante.<br/>Excelente purificadora de ar para ambientes internos.<br/>Adapta-se muito bem a locais com menor incidência de luz solar direta.", "https://images.unsplash.com/photo-1593482834249-f0896792376d?q=80&w=1000&auto=format&fit=crop", "Lírio-da-Paz", 54.9m },
                    { 8L, "Cactos", "Cacto ornamental de crescimento erguido e marcante, ideal para projetos paisagísticos e decorações modernas.<br/>Extremamente resistente e de baixíssima manutenção.<br/>Exige sol pleno ou luz direta intensa.", "https://images.unsplash.com/photo-1509205477838-a534e43a849f?q=80&w=1000&auto=format&fit=crop", "Cacto San Pedro", 69.9m },
                    { 9L, "Planta de Interior", "Surpreende pelos padrões geométricos únicos e tons de roxo na parte inferior de suas folhas.<br/>Gosta de ambientes úmidos, sombra parcial e solo leve.<br/>Um verdadeiro espetáculo de cores naturais para dentro de casa.", "https://images.unsplash.com/photo-1606856540909-6af86992d9d8?q=80&w=1000&auto=format&fit=crop", "Calathea Medallion (Planta-Pavão)", 79.9m },
                    { 10L, "Planta Pendente", "Planta trepadeira resistente, ideal para cultivo em prateleiras altas ou suportes suspensos.<br/>Seus ramos pendentes criam um efeito cascata belíssimo.<br/>Extremamente adaptável a diferentes condições de luz interna.", "https://images.unsplash.com/photo-1598880940371-c756e015ba45?q=80&w=1000&auto=format&fit=crop", "Jiboia Verde (Epipremnum aureum)", 49.99m },
                    { 11L, "Planta de Interior", "Planta arbustiva de visual escultural e tronco robusto.<br/>Ótima opção para cantos de salas e áreas externas iluminadas.<br/>Resistente a períodos curtos de seca.", "https://images.unsplash.com/photo-1525498128493-380d1990a112?q=80&w=1000&auto=format&fit=crop", "Yucca Elephantipes (Yuca)", 119.9m },
                    { 12L, "Planta de Interior", "Possui folhas marcantes com nervuras avermelhadas que se fecham à noite, como em sinal de prece.<br/>Perfeita para mesas de centro e aparadores com meia-luz.<br/>Adora umidade e carinho.", "https://images.unsplash.com/photo-1520302450370-7a2113d5b86f?q=80&w=1000&auto=format&fit=crop", "Maranta Leuconeura (Planta-Oração)", 45.9m },
                    { 13L, "Planta de Interior", "Conhecida por sua alta resistência, a zamioculca sobrevive bem em ambientes com pouca luz e regas esporádicas.<br/>Folhas verdes escuras com brilho natural impressionante.<br/>A planta perfeita para quem costuma esquecer de regar.", "https://images.unsplash.com/photo-1632834379967-a0ce5cb2544e?q=80&w=1000&auto=format&fit=crop", "Zamioculca em Vaso", 79.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "plant",
                keyColumn: "id",
                keyValue: 13L);
        }
    }
}
