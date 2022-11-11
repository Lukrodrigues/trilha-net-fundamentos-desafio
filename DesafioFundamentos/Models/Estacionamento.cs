namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //IMPLEMENTADO//
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(new Veiculo{Placa = Console.ReadLine().ToUpper(), HorarioDeEntrada = DateTime.Now});

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            //Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine().ToUpper();



            //Verifica se o veículo existe
            if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                

                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = (precoInicial) + precoPorHora * horas;


                // TODO: Remover a placa digitada da lista de veículos
                //   veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
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

                foreach (Veiculo item in veiculos)
                {
                    var diferenciaHoras = (int)Math.Floor(DateTime.Now.Subtract(item.HorarioDeEntrada).TotalHours);

                     decimal valorTotal = (precoInicial) + (precoPorHora * diferenciaHoras);

                    Console.WriteLine($"Placa: {item.Placa.ToString()} - Horario de Entrada : {item.HorarioDeEntrada.ToString("dd/MM/yyyy HH:mm:ss")} Valor atual:{valorTotal}");
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
