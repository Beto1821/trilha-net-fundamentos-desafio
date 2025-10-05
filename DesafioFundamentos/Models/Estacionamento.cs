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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            
            // Validação de entrada
            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"Veículo {placa.ToUpper()} cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida! Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            if (veiculos.Any())
            {
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{veiculos[i]}");
                }
            } else
            {
                Console.WriteLine("Não há veículos estacionados.");
                return; // Sai do método se não houver veículos
            }
            string placa = Console.ReadLine();

            // Verifica se o veículo existe ANTES de remover
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    // Calcula o valor total
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    
                    // Remove o veículo da lista
                    veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper());

                    Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida! Digite um número válido.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
