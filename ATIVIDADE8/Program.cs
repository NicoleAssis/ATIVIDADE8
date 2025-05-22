using System;
using System.Collections.Generic;

namespace ProjetoPOO
{
    // ==================== 1. Classes e Construtores ====================
    class Animal
    {
        public string Nome { get; set; }

        public Animal(string nome)
        {
            Nome = nome;
        }

        public virtual void FazerSom()
        {
            Console.WriteLine($"{Nome} faz um som.");
        }
    }

    class Gato : Animal
    {
        public Gato(string nome) : base(nome) { }

        public override void FazerSom()
        {
            Console.WriteLine($"{Nome} diz: Miau!");
        }
    }

    // ==================== 2. Herança ====================
    class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Veiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Veículo: {Marca} {Modelo}");
        }

        public virtual void Acelerar()
        {
            Console.WriteLine("O veículo está acelerando...");
        }
    }

    class Carro : Veiculo
    {
        public Carro(string marca, string modelo) : base(marca, modelo) { }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Carro: {Marca} {Modelo}");
        }

        public override void Acelerar()
        {
            Console.WriteLine($"O carro {Marca} {Modelo} está acelerando rapidamente.");
        }
    }

    class Moto : Veiculo
    {
        public Moto(string marca, string modelo) : base(marca, modelo) { }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Moto: {Marca} {Modelo}");
        }

        public override void Acelerar()
        {
            Console.WriteLine($"A moto {Marca} {Modelo} acelera com agilidade.");
        }
    }

    // ==================== 3. Polimorfismo ====================
    abstract class Forma
    {
        public abstract double CalcularArea();
    }

    class Retangulo : Forma
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

        public override double CalcularArea()
        {
            return Largura * Altura;
        }
    }

    class Circulo : Forma
    {
        public double Raio { get; set; }

        public Circulo(double raio)
        {
            Raio = raio;
        }

        public override double CalcularArea()
        {
            return Math.PI * Raio * Raio;
        }
    }

    class Funcionario
    {
        public string Nome { get; set; }

        public Funcionario(string nome)
        {
            Nome = nome;
        }

        public virtual decimal CalcularSalario()
        {
            return 0;
        }
    }

    class Gerente : Funcionario
    {
        public Gerente(string nome) : base(nome) { }

        public override decimal CalcularSalario()
        {
            return 10000;
        }
    }

    class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(string nome) : base(nome) { }

        public override decimal CalcularSalario()
        {
            return 7000;
        }
    }

    // ==================== 4. Combinação de Conceitos ====================
    class ContaBancaria
    {
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; }

        public ContaBancaria(string numeroConta, decimal saldo)
        {
            NumeroConta = numeroConta;
            Saldo = saldo;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de {valor:C} realizado. Saldo atual: {Saldo:C}");
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado. Saldo atual: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }
    }

    class ContaPoupanca : ContaBancaria
    {
        public decimal TaxaJuros { get; set; }

        public ContaPoupanca(string numeroConta, decimal saldo, decimal taxaJuros)
            : base(numeroConta, saldo)
        {
            TaxaJuros = taxaJuros;
        }

        public override void Sacar(decimal valor)
        {
            decimal taxa = valor * TaxaJuros;
            decimal total = valor + taxa;

            if (total <= Saldo)
            {
                Saldo -= total;
                Console.WriteLine($"Saque de {valor:C} + taxa {taxa:C}. Saldo atual: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque com taxa.");
            }
        }
    }

    class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public virtual void MostrarDetalhes()
        {
            Console.WriteLine($"Produto: {Nome} - Preço: {Preco:C}");
        }
    }

    class ProdutoEletronico : Produto
    {
        public ProdutoEletronico(string nome, decimal preco) : base(nome, preco) { }

        public override void MostrarDetalhes()
        {
            Console.WriteLine($"Eletrônico: {Nome} - Preço: {Preco:C}");
        }
    }

    class ProdutoAlimenticio : Produto
    {
        public ProdutoAlimenticio(string nome, decimal preco) : base(nome, preco) { }

        public override void MostrarDetalhes()
        {
            Console.WriteLine($"Alimento: {Nome} - Preço: {Preco:C}");
        }
    }

    // ==================== 5. Encapsulamento ====================
    class ProdutoEncapsulado
    {
        private string nome;
        private decimal preco;

        public ProdutoEncapsulado(string nome, decimal preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public decimal Preco
        {
            get { return preco; }
            set
            {
                if (value >= 0)
                    preco = value;
                else
                    Console.WriteLine("O preço não pode ser negativo.");
            }
        }
    }

    class Pessoa
    {
        private string nome;
        private int idade;

        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }

        public void Aniversario()
        {
            idade++;
            Console.WriteLine($"{nome} fez aniversário! Agora tem {idade} anos.");
        }
    }

    class Endereco
    {
        private string rua;
        private int numero;
        private string cidade;

        public Endereco(string rua, int numero, string cidade)
        {
            this.rua = rua;
            this.numero = numero;
            this.cidade = cidade;
        }

        public void ExibirEndereco()
        {
            Console.WriteLine($"{rua}, {numero} - {cidade}");
        }
    }

    class FuncionarioEncapsulado
    {
        private string nome;
        private decimal salario;

        public FuncionarioEncapsulado(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;
        }

        public void AumentarSalario(decimal percentual)
        {
            salario += salario * percentual / 100;
            Console.WriteLine($"{nome} teve um aumento! Novo salário: {salario:C}");
        }
    }

    // ==================== MAIN ====================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======= Animais =======");
            Animal animal = new Animal("Animal Genérico");
            animal.FazerSom();

            Gato gato = new Gato("Felix");
            gato.FazerSom();

            Console.WriteLine("\n======= Veículos =======");
            Carro carro = new Carro("Toyota", "Corolla");
            Moto moto = new Moto("Honda", "CB500");

            carro.MostrarInfo();
            carro.Acelerar();

            moto.MostrarInfo();
            moto.Acelerar();

            Console.WriteLine("\n======= Formas =======");
            List<Forma> formas = new List<Forma>
            {
                new Retangulo(5, 3),
                new Circulo(4)
            };

            foreach (var forma in formas)
            {
                Console.WriteLine($"Área: {forma.CalcularArea():F2}");
            }

            Console.WriteLine("\n======= Funcionários =======");
            List<Funcionario> funcionarios = new List<Funcionario>
            {
                new Gerente("Ana"),
                new Desenvolvedor("Carlos")
            };

            foreach (var func in funcionarios)
            {
                Console.WriteLine($"{func.Nome} - Salário: {func.CalcularSalario():C}");
            }

            Console.WriteLine("\n======= Conta Bancária =======");
            ContaBancaria conta = new ContaBancaria("12345", 1000);
            conta.Depositar(500);
            conta.Sacar(300);

            ContaPoupanca poupanca = new ContaPoupanca("67890", 2000, 0.02m);
            poupanca.Sacar(500);

            Console.WriteLine("\n======= Produtos =======");
            List<Produto> produtos = new List<Produto>
            {
                new ProdutoEletronico("Notebook", 3000),
                new ProdutoAlimenticio("Maçã", 5)
            };

            foreach (var produto in produtos)
            {
                produto.MostrarDetalhes();
            }

            Console.WriteLine("\n======= Encapsulamento =======");
            ProdutoEncapsulado prod = new ProdutoEncapsulado("Teclado", 150);
            Console.WriteLine($"{prod.Nome} - {prod.Preco:C}");
            prod.Preco = -10; // Testando validação

            Pessoa pessoa = new Pessoa("Nicole", 20);
            pessoa.Aniversario();

            Endereco endereco = new Endereco("Rua A", 123, "Curitiba");
            endereco.ExibirEndereco();

            FuncionarioEncapsulado funcionarioEnc = new FuncionarioEncapsulado("João", 5000);
            funcionarioEnc.AumentarSalario(10);
        }
    }
}
