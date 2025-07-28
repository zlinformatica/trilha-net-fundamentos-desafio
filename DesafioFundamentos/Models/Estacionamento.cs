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
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para ESTACIONAR:");
            string AdicionarVeiculo = Console.ReadLine();

            veiculos.Add(AdicionarVeiculo);
            Console.WriteLine("Placa cadastrada com SUCESSO!");
        }

        // public Estacionamento(decimal precoInicial, decimal precoPorHora)
        // {
        //     this.precoInicial = precoInicial;
        //     this.precoPorHora = precoPorHora;
        // }
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para LIBERAR:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // <<<IMPLEMENTADO>>>
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {

                // TODO: Pedir para o usuário digitar a quantidade (Inteira) de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // <<<IMPLEMENTADO>>>
                // >>>Adicionado a regra de validação do valor (Inteiro) digitado pelo usuário cujo valor é hora/fração

                int horas = 0;
                bool valido = false;

                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    string resposta = Console.ReadLine();
                    valido = int.TryParse(resposta, out horas);

                    if (!valido)
                    {
                        Console.WriteLine("quantidade inválida. Por favor, digite um número inteiro.");
                    }

                } while (!valido);

                //decimal valorTotal = 0; 
                decimal valorTotal = Math.Round(precoInicial + (precoPorHora * horas), 2);

                // TODO: Remover a placa digitada da lista de veículos
                // <<<IMPLEMENTADO>>>

                if (veiculos.RemoveAll(v => v.Equals(placa, StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    Console.WriteLine($"O valor do estacionamento da placa {placa.ToUpper()} calculado com sucesso.");

                }
                else
                {
                    Console.WriteLine($"Veículo {placa} não encontrado no estacionamento.");
                    return;
                }

                Console.WriteLine($"O veículo {placa.ToUpper()} foi LIBERADO!! E o preço a pagar é de: R$ {valorTotal:F2}");
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
                // <<<IMPLEMENTADO>>>
                 foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"Placa - {veiculo.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
