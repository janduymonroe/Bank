namespace Bank
{
    public class Conta
    {
        private TipoConta tipoConta { get; set; }
        private double saldo { get; set; }
        private double credito { get; set; }
        private string nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (valorSaque <= this.saldo + this.credito )
            {
                //Validação de saldo suficiente
                System.Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.saldo -= valorSaque;
            System.Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;
            System.Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta: " + this.tipoConta + " | ";
            retorno += "Nome: " + this.nome + " | ";
            retorno += "Saldo: " + this.saldo + " | ";
            retorno += "Crédito: " + this.credito;
            return retorno;
        }
    }
}