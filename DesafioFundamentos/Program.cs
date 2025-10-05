using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

// Interface de boas-vindas melhorada
MostrarCabecalho();
Console.WriteLine("🚗 Bem-vindo ao Sistema de Estacionamento! 🚗");
Console.WriteLine(new string('═', 50));

Console.Write("💰 Digite o preço inicial: R$ ");
while (!decimal.TryParse(Console.ReadLine(), out precoInicial) || precoInicial < 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("❌ Preço inválido! Digite um valor válido: R$ ");
    Console.ResetColor();
}

Console.Write("⏰ Digite o preço por hora: R$ ");
while (!decimal.TryParse(Console.ReadLine(), out precoPorHora) || precoPorHora < 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("❌ Preço inválido! Digite um valor válido: R$ ");
    Console.ResetColor();
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    MostrarCabecalho();
    MostrarMenu(precoInicial, precoPorHora);

    string opcaoEscolhida = Console.ReadLine();

    switch (opcaoEscolhida)
    {
        case "1":
            Console.Clear();
            MostrarTitulo("🚗 ADICIONAR VEÍCULO");
            es.AdicionarVeiculo();
            break;

        case "2":
            Console.Clear();
            MostrarTitulo("🚙 REMOVER VEÍCULO");
            es.RemoverVeiculo();
            break;

        case "3":
            Console.Clear();
            MostrarTitulo("📋 LISTAR VEÍCULOS");
            es.ListarVeiculos();
            break;

        case "4":
            MostrarDespedida();
            exibirMenu = false;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Opção inválida! Escolha uma opção válida (1-4)");
            Console.ResetColor();
            break;
    }

    if (exibirMenu)
    {
        Console.WriteLine("\n" + new string('─', 50));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("⏸️  Pressione ENTER para continuar...");
        Console.ResetColor();
        Console.ReadLine();
    }
}

// Métodos auxiliares para interface
static void MostrarCabecalho()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔═══════════════════════════════════════════════════╗");
    Console.WriteLine("║             🚗 SISTEMA DE ESTACIONAMENTO 🚗      ║");
    Console.WriteLine("╚═══════════════════════════════════════════════════╝");
    Console.ResetColor();
}

static void MostrarMenu(decimal precoInicial, decimal precoPorHora)
{
    Console.WriteLine($"💰 Preço inicial: R$ {precoInicial:F2}");
    Console.WriteLine($"⏰ Preço por hora: R$ {precoPorHora:F2}");
    Console.WriteLine();
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("┌─────────────────────────────────────────────┐");
    Console.WriteLine("│                   MENU                      │");
    Console.WriteLine("├─────────────────────────────────────────────┤");
    Console.WriteLine("│  1️⃣  - Cadastrar veículo                   │");
    Console.WriteLine("│  2️⃣  - Remover veículo                     │");
    Console.WriteLine("│  3️⃣  - Listar veículos                     │");
    Console.WriteLine("│  4️⃣  - Encerrar                            │");
    Console.WriteLine("└─────────────────────────────────────────────┘");
    Console.ResetColor();
    
    Console.Write("🔹 Digite sua opção: ");
}

static void MostrarTitulo(string titulo)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(new string('═', titulo.Length + 4));
    Console.WriteLine($"  {titulo}  ");
    Console.WriteLine(new string('═', titulo.Length + 4));
    Console.ResetColor();
    Console.WriteLine();
}

static void MostrarDespedida()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("╔═══════════════════════════════════════════════════╗");
    Console.WriteLine("║                    OBRIGADO!                     ║");
    Console.WriteLine("║          Sistema de Estacionamento foi           ║");
    Console.WriteLine("║                 encerrado! 👋                    ║");
    Console.WriteLine("╚═══════════════════════════════════════════════════╝");
    Console.ResetColor();
}
