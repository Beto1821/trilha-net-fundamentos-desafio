namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("🚗 Digite a placa do veículo (ex: ABC-1234): ");
            string placa = Console.ReadLine();
            
            // Validação de entrada
            if (!string.IsNullOrWhiteSpace(placa))
            {
                // Verifica se já existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"⚠️  Veículo {placa.ToUpper()} já está estacionado!");
                    Console.ResetColor();
                }
                else
                {
                    veiculos.Add(placa.ToUpper());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✅ Veículo {placa.ToUpper()} cadastrado com sucesso!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Placa inválida! Tente novamente.");
                Console.ResetColor();
            }
        }

        public void RemoverVeiculo()
        {
            if (!veiculos.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️  Não há veículos estacionados no momento.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("📋 Veículos estacionados:");
            Console.WriteLine(new string('─', 30));
            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"🚗 {i + 1}° - {veiculos[i]}");
            }
            Console.WriteLine(new string('─', 30));
            
            Console.Write("🔍 Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe ANTES de remover
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("⏰ Digite a quantidade de horas estacionado: ");
                
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    // Calcula o valor total
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    
                    // Remove o veículo da lista
                    veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper());

                    Console.WriteLine(new string('─', 40));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✅ Veículo {placa.ToUpper()} foi removido!");
                    Console.WriteLine($"💰 Valor total: R$ {valorTotal:F2}");
                    Console.WriteLine($"   • Preço inicial: R$ {precoInicial:F2}");
                    Console.WriteLine($"   • {horas}h × R$ {precoPorHora:F2} = R$ {precoPorHora * horas:F2}");
                    Console.ResetColor();
                    Console.WriteLine(new string('─', 40));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Quantidade de horas inválida! Digite um número válido.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Veículo não encontrado! Confira se digitou a placa corretamente.");
                Console.ResetColor();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine($"📊 Total de veículos estacionados: {veiculos.Count}");
                Console.WriteLine(new string('═', 45));
                
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"🚗 {i + 1:D2}° - {veiculos[i]}");
                    Console.ResetColor();
                }
                
                Console.WriteLine(new string('═', 45));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"💰 Preço por hora: R$ {precoPorHora:F2}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("📭 Não há veículos estacionados no momento.");
                Console.WriteLine("🚗 Use a opção 1 para cadastrar o primeiro veículo!");
                Console.ResetColor();
            }
        }
    }
}
