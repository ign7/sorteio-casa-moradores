// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;


namespace sorteio
{
    class cadastroMorador
    {
        public string cpf;
        public string nome;
        public double dependentes;
        public double renda;
        public string tell;
        public string endereco;
    }
    class Program
    {
        public static int m;
        public static int n;
        public static int cont;
        public static int ContDeN;
        public static double salarioMinimo = 1212;
        public static Random rnd = new Random();



       
        public static void Linha()
        {
            Console.WriteLine(" ");
            Console.WriteLine("==================================================");
            Console.WriteLine(" ");
        }



        //imprime a renda percapita dos moradores cadastrados na lista do sorteio renda percapita = renda/dependentes; 
        public static void RendaPorPessoa(SortedList matricula)
        {
            double RendaPercapta = 0;
            foreach (DictionaryEntry moradores in matricula)
            {
                RendaPercapta = ((cadastroMorador)matricula[moradores.Key]).renda / ((cadastroMorador)matricula[moradores.Key]).dependentes;
                Console.WriteLine("Nome : " + ((cadastroMorador)matricula[moradores.Key]).nome + " Renda per capita : R$" + RendaPercapta);
            }
        }

        //SORTEIO 
        public static void Sorteio(SortedList matricula)
        {
            int resp = 0;
            ArrayList listaSorteio = new ArrayList();

                   Console.WriteLine("digite a quantidade de casas a serem sorteadas ");
                   int casas = int.Parse(Console.ReadLine());

            for (int i = 0; i < casas; i++)
            {

                Console.WriteLine("Bem vindo ao sorteio aperte enter  para sortear  morador da " + (i + 1) + "° casa ");
                Console.ReadKey();
                Console.WriteLine(" ");

                foreach (DictionaryEntry moradores in matricula)
                    listaSorteio.Add(((cadastroMorador)matricula[moradores.Key]));
                resp = rnd.Next(listaSorteio.Count);

                if (((cadastroMorador)listaSorteio[resp]).renda <= salarioMinimo)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("PARABENS ! " + ((cadastroMorador)listaSorteio[resp]).nome + " você foi o ganhador(a) do sorteio da  " + (i + 1) + "° casa ");
                    Console.WriteLine(" ");
                    Console.WriteLine("DADOS DO GANHADOR (FAIXA 1)");
                    Console.WriteLine("Nome : " + ((cadastroMorador)listaSorteio[resp]).nome + " CPF :" + ((cadastroMorador)listaSorteio[resp]).cpf);
                    Console.WriteLine("Renda: " + ((cadastroMorador)listaSorteio[resp]).renda + " Dependentes :" + ((cadastroMorador)listaSorteio[resp]).dependentes + " Telefone :" + ((cadastroMorador)listaSorteio[resp]).tell);
                    Console.WriteLine("Endereço: " + ((cadastroMorador)listaSorteio[resp]).endereco);
                    Console.WriteLine(" ");
                }
                if (((cadastroMorador)listaSorteio[resp]).renda > salarioMinimo && ((cadastroMorador)listaSorteio[resp]).renda <= salarioMinimo * 3)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("PARABENS ! " + ((cadastroMorador)listaSorteio[resp]).nome + " você foi o ganhador(a) do sorteio da  " + (i + 1) + "° casa ");
                    Console.WriteLine(" ");
                    Console.WriteLine("DADOS DO GANHADOR (FAIXA 2)");
                    Console.WriteLine("Nome: " + ((cadastroMorador)listaSorteio[resp]).nome + " CPF :" + ((cadastroMorador)listaSorteio[resp]).cpf);
                    Console.WriteLine("Renda: " + ((cadastroMorador)listaSorteio[resp]).renda + " Dependentes :" + ((cadastroMorador)listaSorteio[resp]).dependentes + " Telefone :" + ((cadastroMorador)listaSorteio[resp]).tell);
                    Console.WriteLine("Endereço: " + ((cadastroMorador)listaSorteio[resp]).endereco);
                    Console.WriteLine(" ");
                }
            }
                       
        }
            
            
        


        //apaga um morador na lista do sorteio
        public static void ApagaMorador(SortedList matricula, Queue FilaDeEspera)
        {
            //ContDeN--;
            string pesquisa = " ";
            Console.WriteLine("Digite o CPF do morador que deseja excluir");
            pesquisa = Console.ReadLine();
            if (matricula.ContainsKey(pesquisa))            
                matricula.Remove(pesquisa);
                Console.WriteLine("CPF ("+pesquisa+") removido com sucesso...");
                Console.WriteLine(" ");
                Console.WriteLine("Adicionando primeiro morador da fila de espera...");
                Console.WriteLine(" ");
            matricula.Add(((cadastroMorador)FilaDeEspera.Peek()).cpf, ((cadastroMorador)FilaDeEspera.Peek()));
                FilaDeEspera.Dequeue();            
        }

        //imprime listagem simples e completa da fila de espera 
        public static void Fila(Queue FilaDeEspera)
        {
            int opcao = 0;
            while (opcao != 3)
            {
                Console.WriteLine("1-listagem simples :");
                Console.WriteLine("2-listagem completa :");
                Console.WriteLine("3-sair :");
                opcao = int.Parse(Console.ReadLine());
                while (opcao > 2 && opcao < 1)
                {
                    Console.WriteLine("1-listagem simples :");
                    Console.WriteLine("2-listagem completa :");
                    Console.WriteLine("3- sair :");
                    opcao = int.Parse(Console.ReadLine());
                }
                switch (opcao)
                {
                    case 1:                        
                            foreach (cadastroMorador pessoas in FilaDeEspera)                       
                            if (pessoas.renda <= salarioMinimo)
                            {
                                Linha();
                                Console.WriteLine( "                (FAIXA 1) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("Nome : " + pessoas.nome + " CPF " + pessoas.cpf + " Renda familiar R$ " + pessoas.renda);
                                Linha();
                            }
                        foreach (cadastroMorador pessoas in FilaDeEspera)
                            if (pessoas.renda > salarioMinimo && pessoas.renda<=salarioMinimo*3)
                            {
                                Linha();
                                Console.WriteLine("                 (FAIXA 2) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("Nome : " + pessoas.nome + " CPF " + pessoas.cpf + " Renda familiar R$ " + pessoas.renda);
                                Linha();
                            }

                                break;
                    case 2:
                        foreach (cadastroMorador pessoas in FilaDeEspera)
                            if (pessoas.renda <= salarioMinimo)
                            {
                                Linha();
                                Console.WriteLine("                (FAIXA 1) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("CPF - " + pessoas.cpf + " Nome -" + pessoas.nome);
                                Console.WriteLine("Qtde. de dependentes -" + pessoas.dependentes + " Renda Familiar -" + pessoas.renda);
                                Console.WriteLine("telefone - " + pessoas.tell);
                                Console.WriteLine("Endereço - " + pessoas.endereco);
                                Console.WriteLine(" ");
                                Linha();
                            }
                        foreach (cadastroMorador pessoas in FilaDeEspera)
                            if (pessoas.renda > salarioMinimo && pessoas.renda <= salarioMinimo * 3)
                            {
                                Linha();
                                Console.WriteLine("                (FAIXA 2) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("CPF - " + pessoas.cpf + " Nome -" + pessoas.nome);
                                Console.WriteLine("Qtde. de dependentes - " + pessoas.dependentes + " Renda Familiar -" + pessoas.renda);
                                Console.WriteLine("telefone - " + pessoas.tell);
                                Console.WriteLine("Endereço - " + pessoas.endereco);
                                Console.WriteLine(" ");
                                Linha();
                            }

                                break;
                }
            }
        }


        //imprime listagem simples e completa da fila do sorteio
        public static void ImpListMorador(SortedList matricula)
        {
            int opcao = 0;
            while (opcao != 3)
            {
                Console.WriteLine("1-listagem simples :");
                Console.WriteLine("2-listagem completa :");
                Console.WriteLine("3-sair :");
                opcao = int.Parse(Console.ReadLine());
                while (opcao > 2 && opcao < 1)
                {
                    Console.WriteLine("1-listagem simples :");
                    Console.WriteLine("2-listagem completa :");
                    Console.WriteLine("3- sair :");
                    opcao = int.Parse(Console.ReadLine());
                }
                switch (opcao)
                {
                    case 1:
                        foreach (DictionaryEntry moradores in matricula)                       
                            if (((cadastroMorador)matricula[moradores.Key]).renda <= salarioMinimo)
                            {
                                Linha();
                                Console.WriteLine("               (FAIXA 1) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("Nome - " + ((cadastroMorador)matricula[moradores.Key]).nome + " CPF - " + ((cadastroMorador)matricula[moradores.Key]).cpf + " Renda Familiar -  R$ " + ((cadastroMorador)matricula[moradores.Key]).renda);
                                Linha();
                            }
                        
                        foreach (DictionaryEntry moradores in matricula)                       
                            if (((cadastroMorador)matricula[moradores.Key]).renda > salarioMinimo && ((cadastroMorador)matricula[moradores.Key]).renda <= salarioMinimo * 3)
                            {
                                Linha();
                                Console.WriteLine("               (FAIXA 2) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("Nome - " + ((cadastroMorador)matricula[moradores.Key]).nome + " CPF - " + ((cadastroMorador)matricula[moradores.Key]).cpf + " Renda Familiar -  R$ " + ((cadastroMorador)matricula[moradores.Key]).renda);
                                Linha();
                            }
                        
                        break;
                    case 2:
                        foreach (DictionaryEntry moradores in matricula)
                            if (((cadastroMorador)matricula[moradores.Key]).renda <= salarioMinimo)
                            {
                                Linha();
                                Console.WriteLine("                (FAIXA 1) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("CPF - " + ((cadastroMorador)matricula[moradores.Key]).cpf + " Nome - " + ((cadastroMorador)matricula[moradores.Key]).nome);
                                Console.WriteLine("Qtde. de dependentes - " + ((cadastroMorador)matricula[moradores.Key]).dependentes + " Renda Familiar - " + ((cadastroMorador)matricula[moradores.Key]).renda);
                                Console.WriteLine("telefone : " + ((cadastroMorador)matricula[moradores.Key]).tell);
                                Console.WriteLine("Endereço : " + ((cadastroMorador)matricula[moradores.Key]).endereco);
                                //Console.WriteLine(" ");
                                Linha();
                            }
                        foreach (DictionaryEntry moradores in matricula)
                            if (((cadastroMorador)matricula[moradores.Key]).renda > salarioMinimo && ((cadastroMorador)matricula[moradores.Key]).renda <= salarioMinimo * 3)
                            {
                                Linha();
                                Console.WriteLine("                (FAIXA 2) ");
                                Console.WriteLine("==================================================");
                                Console.WriteLine(" ");
                                Console.WriteLine("CPF - " + ((cadastroMorador)matricula[moradores.Key]).cpf + " Nome - " + ((cadastroMorador)matricula[moradores.Key]).nome);
                                Console.WriteLine("Qtde. de dependentes - " + ((cadastroMorador)matricula[moradores.Key]).dependentes + " Renda Familiar - " + ((cadastroMorador)matricula[moradores.Key]).renda);
                                Console.WriteLine("telefone : " + ((cadastroMorador)matricula[moradores.Key]).tell);
                                Console.WriteLine("Endereço : " + ((cadastroMorador)matricula[moradores.Key]).endereco);
                                //Console.WriteLine(" ");
                                Linha();
                            }
                               break;
                }
            }
        }
        //pesquisa o morador por CPF 
        public static void pesquisaMorador(SortedList matricula, Queue FilaDeEspera)
        {
            string pesquisa = " ";
            Boolean sair = true;
            while (sair == true)
            {
                Console.WriteLine("Digite o seu CPF ou (-1) para sair da pesquisa");                
                pesquisa = Console.ReadLine();
                if (pesquisa == "-1")
                    sair = false;

                if (matricula.ContainsKey(pesquisa))
                {
                    Console.WriteLine("nome : " + ((cadastroMorador)matricula[pesquisa]).nome);
                    Console.WriteLine("CPF : " + ((cadastroMorador)matricula[pesquisa]).cpf);
                    Console.WriteLine("endereço : " + ((cadastroMorador)matricula[pesquisa]).endereco);
                    Console.WriteLine("renda familiar : " + ((cadastroMorador)matricula[pesquisa]).renda);
                    Console.WriteLine("tell : " + ((cadastroMorador)matricula[pesquisa]).tell);
                    Console.WriteLine("dependentes : " + ((cadastroMorador)matricula[pesquisa]).dependentes);
                }               
                else
                {
                    foreach (cadastroMorador pessoas in FilaDeEspera)
                        if (pessoas.cpf.Equals(pesquisa))
                        {
                            Console.WriteLine(pessoas.nome+" nao esta na lista de sorteio, mais aguarda na fila de espera : ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Nome : " + pessoas.nome + " CPF " + pessoas.cpf + " Renda familiar R$ " + pessoas.renda);
                        }                
                }
            }
        }

        //parametros iniciais
        public static void ParametroInicial(SortedList matricula,Queue FilaDeEspera)
        {
            matricula.Clear();
            FilaDeEspera.Clear();

            cont = 0;
            ContDeN = 0;
            Console.WriteLine("digite a quantidade de moradores(M1)");
            int m1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("digite a quantidade de moradores 2(M2)");
            int m2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Tamanho da fila da lista de espera");
            n = Int32.Parse(Console.ReadLine());
            m = m1 + m2;
        }
        //cadastro de moradores na lista de sorteio e na fila de espera caso a lista de sorteio esteja cheia
        public static void Cadastro(SortedList matricula, Queue FilaDeEspera)
        {
            if (n == ContDeN && m == cont)
            {
                Console.WriteLine("cadastro encerrado....");
                Console.WriteLine(" ");
            }

            else
            {
                if (m == cont)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("lista do sorteio já encerrada,cadastre-se na fila de espera :");
                    Console.WriteLine(" ");
                    for (int i = 0; i < n; i++)
                    {
                        cadastroMorador Morador = new cadastroMorador();
                        Console.WriteLine(" ");
                        Console.WriteLine("Nome : ");
                        Morador.nome = Console.ReadLine();
                        Console.WriteLine("CPF :");
                        Morador.cpf = Console.ReadLine();
                        Console.WriteLine("Quantidade de dependentes:");
                        Morador.dependentes = double.Parse(Console.ReadLine());                       
                        Console.WriteLine("Renda familiar :");
                        Morador.renda = double.Parse(Console.ReadLine());
                        while (Morador.renda > salarioMinimo * 3)
                        {
                            if (Morador.renda > salarioMinimo * 3)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Salario incompativel com as regras do sorteio,sua renda deve ser de ate 3 salarios minimos ");
                                Console.WriteLine(" ");
                                Console.WriteLine("Digite um salario compativel com as regras  (R$ 3636,00 Teto máximo): ");
                                Morador.renda = double.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Telefone de contato :");
                        Morador.tell = Console.ReadLine();
                        Console.WriteLine("Endereço completo :");
                        Morador.endereco = Console.ReadLine();
                        FilaDeEspera.Enqueue(Morador);
                        
                        ContDeN++;
                    }
                }
                else
                {
                    for (int i = 0; i < m; i++)
                    {
                        cadastroMorador Morador = new cadastroMorador();
                        Console.WriteLine(" ");
                        Console.WriteLine("Nome : ");
                        Morador.nome = Console.ReadLine();
                        Console.WriteLine("CPF :");
                        Morador.cpf = Console.ReadLine();
                        Console.WriteLine("Quantidade de dependentes :");
                        Morador.dependentes = double.Parse(Console.ReadLine());
                        Console.WriteLine("Renda familiar :");
                        Morador.renda = double.Parse(Console.ReadLine());
                        while (Morador.renda > salarioMinimo * 3)
                        {
                            if (Morador.renda > salarioMinimo * 3)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Salario incompativel com as regras do sorteio,sua renda deve ser de ate 3 salarios minimos ");
                                Console.WriteLine(" ");
                                Console.WriteLine("Digite um salario compativel com as regras (R$ 3636,00 Teto máximo): ");
                                Morador.renda = double.Parse(Console.ReadLine());
                            }
                        }
                            Console.WriteLine(" ");
                            Console.WriteLine("Telefone de contato :");
                            Morador.tell = Console.ReadLine();
                            Console.WriteLine("Endereço completo :");
                            Morador.endereco = Console.ReadLine();
                            matricula.Add(Morador.cpf, Morador);                        
                        cont++;
                    }
                }
            }
        }

        //menu de opçoes
        public static void op(SortedList matricula, Queue FilaDeEspera)
        {
            int menu = 0;
            while (menu != 9)
            {
                Console.WriteLine(" ");
                Console.WriteLine("1-Cadastro");
                Console.WriteLine("2-Pesquisar morador");
                Console.WriteLine("3-Parametros");
                Console.WriteLine("4-Imprimir lista de moradores ");
                Console.WriteLine("5-Imprimir fila de espera");
                Console.WriteLine("6-Excluir/desistência");
                Console.WriteLine("7-Sorteio");
                Console.WriteLine("8-Renda per capita");
                Console.WriteLine("9-Sair");
                Console.WriteLine(" ");
                menu = Int32.Parse(Console.ReadLine());
                while (menu > 8 && menu < 1)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("1-Cadastro");
                    Console.WriteLine("2-Pesquisar morador");
                    Console.WriteLine("3-Parametros");
                    Console.WriteLine("4-Imprimir lista de moradores ");
                    Console.WriteLine("5-Imprimir fila de espera");
                    Console.WriteLine("6-Excluir/desistência");
                    Console.WriteLine("7-Sorteio");
                    Console.WriteLine("8-Renda per capita");
                    Console.WriteLine("9-Sair");
                    Console.WriteLine(" ");
                    menu = Int32.Parse(Console.ReadLine());
                }
                switch (menu)
                {
                    case 1:
                        Cadastro(matricula, FilaDeEspera);
                        break;
                    case 2:
                        pesquisaMorador(matricula, FilaDeEspera);
                        break;
                    case 3:
                        ParametroInicial( matricula,  FilaDeEspera);
                        break;
                    case 4:
                        ImpListMorador(matricula);
                        break;
                    case 5:
                        Fila(FilaDeEspera);
                        break;
                    case 6:
                        ApagaMorador(matricula, FilaDeEspera);
                        break;
                    case 7:
                        Sorteio(matricula);
                        break;
                    case 8:
                        RendaPorPessoa(matricula);
                        break;
                }

            }
        }

        public static void Main(string[] args)
        {
            SortedList matricula = new SortedList();
            Queue FilaDeEspera = new Queue();
            ParametroInicial(matricula, FilaDeEspera);
            op(matricula, FilaDeEspera);
        }
    }
}
