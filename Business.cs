using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SlnArCond
{
    public class ValidaCPF
    {
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }

    public class ValidaCNPJ
    {
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }

    public class pCliente
    {
        private int _Cod_Cliente;
        public int Cod_Cliente
        {
            get { return _Cod_Cliente; }
            set { _Cod_Cliente = value; }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Rg;
        public string Rg
        {
            get { return _Rg; }
            set { _Rg = value; }
        }

        private string _Cpf;
        public string Cpf
        {
            get { return _Cpf; }
            set { _Cpf = value; }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _DtNascimento;
        public DateTime DtNascimento
        {
            get { return _DtNascimento; }
            set { _DtNascimento = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Uf;
        public string Uf
        {
            get { return _Uf; }
            set { _Uf = value; }
        }

        private string _Lougradouro;
        public string Lougradouro
        {
            get { return _Lougradouro; }
            set { _Lougradouro = value; }
        }

        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        private string _Cep;
        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }

    }

    public class mCliente
    {
        public void InsCliente(pCliente P)
        {
            Dao D = new Dao();

            D.InsCliente(P.Nome, P.Rg, P.Cpf, P.Telefone, P.Email, P.DtNascimento, P.Estado, P.Uf, P.Lougradouro, P.Complemento, P.Bairro, P.Cep);

        }
        public List<pCliente> SelCliente(string Cpf)
        {
            Dao D = new Dao();
            DataTable DT = D.SelCliente(Cpf);
            List<pCliente> LC = new List<pCliente>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pCliente P = new pCliente();
                P.Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_Cliente"]);
                P.Nome = DT.Rows[i]["Nome"].ToString();
                P.Rg = DT.Rows[i]["Rg"].ToString();
                P.Cpf = DT.Rows[i]["Cpf"].ToString();
                P.Telefone = DT.Rows[i]["Telefone"].ToString();
                P.Email = DT.Rows[i]["Email"].ToString();
                P.DtNascimento = Convert.ToDateTime(DT.Rows[i]["DTNascimento"]);
                P.Estado = DT.Rows[i]["Estado"].ToString();
                P.Uf = DT.Rows[i]["Uf"].ToString();
                P.Lougradouro = DT.Rows[i]["Lougradouro"].ToString();
                P.Complemento = DT.Rows[i]["Complemento"].ToString();
                P.Bairro = DT.Rows[i]["Bairro"].ToString();
                P.Cep = DT.Rows[i]["Cep"].ToString();
                LC.Add(P);
            }
            return LC;

        }
        public List<pCliente> SelCliente()
        {
            Dao D = new Dao();
            DataTable DT = D.SelCliente();
            List<pCliente> LC = new List<pCliente>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pCliente P = new pCliente();
                P.Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_Cliente"]);
                P.Nome = DT.Rows[i]["Nome"].ToString();
                LC.Add(P);
            }
            return LC;

        }
        public void ExcCliente(string Cpf)
        {
            Dao D = new Dao();
            D.ExcCliente(Cpf);
        }
        public void AtuCliente(pCliente P)
        {
            Dao D = new Dao();
            D.AtuCliente(P.Nome, P.Rg, P.Cpf, P.Telefone, P.Email, P.DtNascimento, P.Estado, P.Uf, P.Lougradouro, P.Complemento, P.Bairro, P.Cep);


        }
    }

    public class pFuncionario
    {

        private int _Matr_Func;

        public int Matr_Func
        {
            get { return _Matr_Func; }
            set { _Matr_Func = value; }
        }


        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Rg;
        public string Rg
        {
            get { return _Rg; }
            set { _Rg = value; }
        }

        private string _Cpf;
        public string Cpf
        {
            get { return _Cpf; }
            set { _Cpf = value; }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _DtNascimento;
        public DateTime DtNascimento
        {
            get { return _DtNascimento; }
            set { _DtNascimento = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Uf;
        public string Uf
        {
            get { return _Uf; }
            set { _Uf = value; }
        }

        private string _Lougradouro;
        public string Lougradouro
        {
            get { return _Lougradouro; }
            set { _Lougradouro = value; }
        }

        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        private string _Cep;
        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }

        private string _Senha;

        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }
        private string _Cargo;

        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

    }

    public class mFuncionario
    {
        public void InsFuncionario(pFuncionario P)
        {
            Dao D = new Dao();

            D.InsFuncionario(P.Nome, P.Rg, P.Cpf, P.Telefone, P.Email, P.DtNascimento, P.Estado, P.Uf, P.Lougradouro, P.Complemento, P.Bairro, P.Cep, P.Senha, P.Cargo);

        }
        public List<pFuncionario> SelFuncionario(string Cpf)
        {
            Dao D = new Dao();
            DataTable DT = D.SelFuncionario(Cpf);
            List<pFuncionario> LC = new List<pFuncionario>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pFuncionario P = new pFuncionario();
                P.Matr_Func = Convert.ToInt32(DT.Rows[i]["Matr_Func"]);
                P.Nome = DT.Rows[i]["Nome"].ToString();
                P.Rg = DT.Rows[i]["Rg"].ToString();
                P.Cpf = DT.Rows[i]["Cpf"].ToString();
                P.Telefone = DT.Rows[i]["Telefone"].ToString();
                P.Email = DT.Rows[i]["Email"].ToString();
                P.DtNascimento = Convert.ToDateTime(DT.Rows[i]["DTNascimento"]);
                P.Estado = DT.Rows[i]["Estado"].ToString();
                P.Uf = DT.Rows[i]["Uf"].ToString();
                P.Lougradouro = DT.Rows[i]["Lougradouro"].ToString();
                P.Complemento = DT.Rows[i]["Complemento"].ToString();
                P.Bairro = DT.Rows[i]["Bairro"].ToString();
                P.Cep = DT.Rows[i]["Cep"].ToString();
                P.Senha = DT.Rows[i]["Senha"].ToString();
                P.Cargo = DT.Rows[i]["Cargo"].ToString();
                LC.Add(P);
            }
            return LC;

        }

        public void ExcFuncionario(string Cpf)
        {
            Dao D = new Dao();
            D.ExcFuncionario(Cpf);
        }
        public void AtuFuncionario(pFuncionario P)
        {
            Dao D = new Dao();
            D.AtuFuncionario(P.Nome, P.Rg, P.Cpf, P.Telefone, P.Email, P.DtNascimento, P.Estado, P.Uf, P.Lougradouro, P.Complemento, P.Bairro, P.Cep, P.Senha, P.Cargo);
        }
        public List<pFuncionario> SelFun()
        {
            Dao D = new Dao();
            DataTable DT = D.SelFun();
            List<pFuncionario> LC = new List<pFuncionario>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pFuncionario P = new pFuncionario();
                P.Matr_Func = Convert.ToInt32(DT.Rows[i]["Matr_Func"]);
                P.Nome = DT.Rows[i]["Nome"].ToString();
                LC.Add(P);
            }
            return LC;

        }
    }

    public class pFornecedor
    {

        private int _Cod_Fonecedor;

        public int Cod_Fornecedor
        {
            get { return _Cod_Fonecedor; }
            set { _Cod_Fonecedor = value; }
        }

        private string _Razao_Social;

        public string Razao_Social
        {
            get { return _Razao_Social; }
            set { _Razao_Social = value; }
        }

        private string _Cnpj;

        public string Cnpj
        {
            get { return _Cnpj; }
            set { _Cnpj = value; }
        }

        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Tipo_Peca;

        public string Tipo_Peca
        {
            get { return _Tipo_Peca; }
            set { _Tipo_Peca = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Uf;
        public string Uf
        {
            get { return _Uf; }
            set { _Uf = value; }
        }

        private string _Lougradouro;
        public string Lougradouro
        {
            get { return _Lougradouro; }
            set { _Lougradouro = value; }
        }

        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        private string _Cep;
        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }
    }

    public class mFornecedor
    {
        public void InsFornecedor(pFornecedor P)
        {
            Dao D = new Dao();
            D.InsFornecedor(P.Razao_Social, P.Cnpj, P.Telefone, P.Email, P.Tipo_Peca, P.Estado, P.Uf, P.Lougradouro, P.Complemento, P.Bairro, P.Cep);
        }
        public List<pFornecedor> SelFornecedor(string Cnpj)
        {
            Dao D = new Dao();
            DataTable DT = D.SelFornecedor(Cnpj);
            List<pFornecedor> LC = new List<pFornecedor>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pFornecedor P = new pFornecedor();
                P.Cod_Fornecedor = Convert.ToInt32(DT.Rows[i]["Cod_Fornecedor"]);
                P.Razao_Social = DT.Rows[i]["Razao_Social"].ToString();
                P.Cnpj = DT.Rows[i]["Cnpj"].ToString();
                P.Telefone = DT.Rows[i]["Telefone"].ToString();
                P.Email = DT.Rows[i]["Email"].ToString();
                P.Tipo_Peca = (DT.Rows[i]["Tipo_Peca"]).ToString();
                P.Estado = DT.Rows[i]["Estado"].ToString();
                P.Uf = DT.Rows[i]["Uf"].ToString();
                P.Lougradouro = DT.Rows[i]["Lougradouro"].ToString();
                P.Complemento = DT.Rows[i]["Complemento"].ToString();
                P.Bairro = DT.Rows[i]["Bairro"].ToString();
                P.Cep = DT.Rows[i]["Cep"].ToString();
                LC.Add(P);
            }
            return LC;

        }
        public List<pFornecedor> SelFornecedor()
        {
            Dao D = new Dao();
            DataTable DT = D.SelFornecedor();
            List<pFornecedor> LC = new List<pFornecedor>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pFornecedor P = new pFornecedor();
                P.Cod_Fornecedor = Convert.ToInt32(DT.Rows[i]["Cod_Fornecedor"]);
                P.Razao_Social = DT.Rows[i]["Razao_Social"].ToString();
                P.Tipo_Peca = (DT.Rows[i]["Tipo_Peca"]).ToString();
                LC.Add(P);
            }
            return LC;

        }
        public void ExcFornecedor(string Cnpj)
        {
            Dao D = new Dao();
            D.ExcFornecedor(Cnpj);
        }
        public void AtuFornecedor(pFornecedor P)
        {
            Dao D = new Dao();
            D.AtuFornecedor(P.Razao_Social, P.Cnpj, P.Telefone, P.Email, P.Tipo_Peca, P.Estado, P.Uf, P.Lougradouro, P.Complemento, P.Bairro, P.Cep);
        }



    }

    public class pPecas
    {
        private int _Cod_Pecas;

        public int Cod_Pecas
        {
            get { return _Cod_Pecas; }
            set { _Cod_Pecas = value; }
        }


        private string _Descricao;

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }



        private string _Fabricante;

        public string Fabricante
        {
            get { return _Fabricante; }
            set { _Fabricante = value; }
        }

        private string _Modelo;

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        private decimal _Valor_Entrada;

        public decimal Valor_Entrada
        {
            get { return _Valor_Entrada; }
            set { _Valor_Entrada = value; }
        }

        private decimal _Valor_Saida;

        public decimal Valor_Saida
        {
            get { return _Valor_Saida; }
            set { _Valor_Saida = value; }
        }

        private int _Quantidade;

        public int Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        private int _Cod_FornecedorFK;

        public int Cod_FornecedorFK
        {
            get { return _Cod_FornecedorFK; }
            set { _Cod_FornecedorFK = value; }
        }


    }

    public class mPecas
    {
        public void InsPecas(pPecas P)
        {
            Dao D = new Dao();
            D.InsPecas(P.Descricao, P.Fabricante, P.Modelo, P.Valor_Entrada, P.Valor_Saida, P.Quantidade, P.Cod_FornecedorFK);
        }
        public List<pPecas> SelItens(string Descricao)
        {
            Dao D = new Dao();
            DataTable DT = D.SelItens(Descricao);
            List<pPecas> LC = new List<pPecas>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pPecas P = new pPecas();
                P.Cod_Pecas = Convert.ToInt32(DT.Rows[i]["Cod_Pecas"]);
                P.Descricao = DT.Rows[i]["Descricao"].ToString();
                P.Fabricante = DT.Rows[i]["Fabricante"].ToString();
                P.Modelo = DT.Rows[i]["Modelo"].ToString();
                P.Valor_Entrada = Convert.ToDecimal(DT.Rows[i]["Valor_Entrada"]);
                P.Valor_Saida = Convert.ToDecimal(DT.Rows[i]["Valor_Saida"]);
                P.Quantidade = Convert.ToInt32(DT.Rows[i]["Quantidade"]);
                LC.Add(P);
            }
            return LC;
        }
        public List<pPecas> SelRepeater()
        {
            Dao D = new Dao();
            DataTable DT = D.SelRepeater();
            List<pPecas> LC = new List<pPecas>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pPecas P = new pPecas();
                P.Cod_Pecas = Convert.ToInt32(DT.Rows[i]["Cod_Pecas"]);
                P.Descricao = DT.Rows[i]["Descricao"].ToString();
                P.Fabricante = DT.Rows[i]["Fabricante"].ToString();
                P.Modelo = DT.Rows[i]["Modelo"].ToString();
                P.Valor_Entrada = Convert.ToDecimal(DT.Rows[i]["Valor_Entrada"]);
                P.Valor_Saida = Convert.ToDecimal(DT.Rows[i]["Valor_Saida"]);
                P.Quantidade = Convert.ToInt32(DT.Rows[i]["Quantidade"]);
                LC.Add(P);
            }
            return LC;
        }
        public List<pPecas> SelPecas(int Cod_Pecas)
        {
            Dao D = new Dao();
            DataTable DT = D.SelPecas(Cod_Pecas);
            List<pPecas> LC = new List<pPecas>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pPecas P = new pPecas();
                P.Cod_Pecas = Convert.ToInt32(DT.Rows[i]["Cod_Pecas"]);
                P.Descricao = DT.Rows[i]["Descricao"].ToString();
                P.Fabricante = DT.Rows[i]["Fabricante"].ToString();
                P.Modelo = DT.Rows[i]["Modelo"].ToString();
                P.Valor_Entrada = Convert.ToDecimal(DT.Rows[i]["Valor_Entrada"]);
                P.Valor_Saida = Convert.ToDecimal(DT.Rows[i]["Valor_Saida"]);
                P.Quantidade = Convert.ToInt32(DT.Rows[i]["Quantidade"]);
                LC.Add(P);
            }
            return LC;
        }
        public List<pPecas> SelPecas()
        {
            return SelPecas(0);
        }
        public void ExcPecas(int Cod_Pecas)
        {
            Dao D = new Dao();
            D.ExcPecas(Cod_Pecas);
        }
        public void AtuPecas(pPecas P)
        {
            Dao D = new Dao();
            D.AtuPecas(P.Cod_Pecas, P.Descricao, P.Fabricante, P.Modelo, P.Valor_Entrada, P.Valor_Saida, P.Quantidade);
        }

    }

    public class pCarrinho : pPecas
    {
        private int _Quantidade;

        public int pQuantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public void VendPecas(pCarrinho P)
        {
            Dao D = new Dao();
            D.VendPecas(P.Cod_Pecas, P.pQuantidade);
        }

        public decimal Total
        {
            get
            {
                return _Quantidade * Valor_Saida;
            }

        }

    }

    public class pPedido
    {
        private int _Cod_Pedido;

        public int Cod_Pedido
        {
            get { return _Cod_Pedido; }
            set { _Cod_Pedido = value; }
        }

        private decimal _ValorTotal;

        public decimal ValorTotal
        {
            get { return _ValorTotal; }
            set { _ValorTotal = value; }
        }

        private string _FormaPagamento;

        public string FormaPagamento
        {
            get { return _FormaPagamento; }
            set { _FormaPagamento = value; }
        }

        private DateTime _DataPagamento;

        public DateTime DataPagamento
        {
            get { return _DataPagamento; }
            set { _DataPagamento = value; }
        }

        private pCliente _Cliente;

        public pCliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private int _Cod_ClienteFK;

        public int Cod_ClienteFK
        {
            get { return _Cod_ClienteFK; }
            set { _Cod_ClienteFK = value; }
        }


        private int _Matr_FuncFK;

        public int Matr_FuncFK
        {
            get { return _Matr_FuncFK; }
            set { _Matr_FuncFK = value; }
        }





    }

    public class pDataPedido : pPedido
    {
        private DateTime _Data1;

        public DateTime Data1
        {
            get { return _Data1; }
            set { _Data1 = value; }
        }

        private DateTime _Data2;

        public DateTime Data2
        {
            get { return _Data2; }
            set { _Data2 = value; }
        }



    }

    public class mPedido
    {
        public void InsPedido(pPedido P)
        {
            Dao D = new Dao();
            D.InsPedido(P.ValorTotal, P.FormaPagamento, P.DataPagamento, P.Cod_ClienteFK, P.Matr_FuncFK);

        }
        public List<pDataPedido> RelatorioVenda(string FormaPagamento, DateTime Data1, DateTime Data2)
        {
            pDataPedido P = new pDataPedido();
            DataTable DT = new Dao().RelatorioVenda(FormaPagamento, Data1, Data2);
            List<pDataPedido> LC = new List<pDataPedido>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                LC.Add(new pDataPedido()
                {
                    Cod_Pedido = Convert.ToInt32(DT.Rows[i]["Cod_Pedido"]),
                    ValorTotal = Convert.ToDecimal(DT.Rows[i]["ValorTotal"]),
                    FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString(),
                    DataPagamento = Convert.ToDateTime(DT.Rows[i]["DataPagamento"]),
                    Cliente = new pCliente() { Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]), Nome = DT.Rows[i]["Nome"].ToString() }

                });
            }
            return LC;

        }
        public List<pDataPedido> RelatorioVendaFunc(string FormaPagamento, DateTime Data1, DateTime Data2, int Matr_FuncFK)
        {
            pDataPedido P = new pDataPedido();
            DataTable DT = new Dao().RelatorioVendaFunc(FormaPagamento, Data1, Data2, Matr_FuncFK);
            List<pDataPedido> LC = new List<pDataPedido>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                LC.Add(new pDataPedido()
                {
                    Cod_Pedido = Convert.ToInt32(DT.Rows[i]["Cod_Pedido"]),
                    ValorTotal = Convert.ToDecimal(DT.Rows[i]["ValorTotal"]),
                    FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString(),
                    DataPagamento = Convert.ToDateTime(DT.Rows[i]["DataPagamento"]),
                    Cliente = new pCliente() { Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]), Nome = DT.Rows[i]["Nome"].ToString() },
                    Matr_FuncFK = Convert.ToInt32(DT.Rows[i]["Matr_FuncFK"])
                });
            }
            return LC;

        }

    }

    public class pItemPedido
    {
        private int _Cod_ItemPedido;

        public int Cod_ItemPedido
        {
            get { return _Cod_ItemPedido; }
            set { _Cod_ItemPedido = value; }
        }

        private int _Cod_Pecas;

        public int Cod_Pecas
        {
            get { return _Cod_Pecas; }
            set { _Cod_Pecas = value; }
        }

        private string _Descricao;

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        private decimal _Valor_Saida;

        public decimal Valor_Saida
        {
            get { return _Valor_Saida; }
            set { _Valor_Saida = value; }
        }

        private int _pQuantidade;

        public int pQuantidade
        {
            get { return _pQuantidade; }
            set { _pQuantidade = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private int _Cod_Pedido;

        public int Cod_Pedido
        {
            get { return _Cod_Pedido; }
            set { _Cod_Pedido = value; }
        }


    }

    public class mItemPedido
    {
        public void InsItemPedido(pItemPedido P)
        {
            Dao D = new Dao();
            D.InsItemPedido(P.Cod_Pecas, P.Descricao, P.Valor_Saida, P.pQuantidade, P.Total, P.Cod_Pedido);

        }
        public List<pItemPedido> SelecionarVenda(int Cod_Pedido)
        {
            Dao D = new Dao();
            DataTable DT = D.SelecionarVenda(Cod_Pedido);
            List<pItemPedido> LC = new List<pItemPedido>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pItemPedido P = new pItemPedido();
                P.Cod_Pecas = Convert.ToInt32(DT.Rows[i]["Cod_PecasFK"]);
                P.Descricao = DT.Rows[i]["Descricao"].ToString();
                P.Valor_Saida = Convert.ToDecimal(DT.Rows[i]["Valor_Saida"]);
                P.pQuantidade = Convert.ToInt32(DT.Rows[i]["Quantidade"]);
                P.Total = Convert.ToDecimal(DT.Rows[i]["Total"]);
                LC.Add(P);
            }
            return LC;
        }
    }

    public class pManuAr
    {
        private int _Cod_Manutencao;

        public int Cod_Manutencao
        {
            get { return _Cod_Manutencao; }
            set { _Cod_Manutencao = value; }
        }

        private pCliente _Cliente;

        public pCliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private int _Cod_ClienteFK;

        public int Cod_ClienteFK
        {
            get { return _Cod_ClienteFK; }
            set { _Cod_ClienteFK = value; }
        }

        private string _Modelo;

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }


        private string _Marca;

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        private string _NumSerie;

        public string NumSerie
        {
            get { return _NumSerie; }
            set { _NumSerie = value; }
        }

        private DateTime _DataEntrada;

        public DateTime DataEntrada
        {
            get { return _DataEntrada; }
            set { _DataEntrada = value; }
        }

        private DateTime _DataSaida;

        public DateTime DataSaida
        {
            get { return _DataSaida; }
            set { _DataSaida = value; }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Observacao;

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        private decimal _ValorMObra;

        public decimal ValorMObra
        {
            get { return _ValorMObra; }
            set { _ValorMObra = value; }
        }

        private string _FormaPagamento;

        public string FormaPagamento
        {
            get { return _FormaPagamento; }
            set { _FormaPagamento = value; }
        }


        private int _Matr_FuncFK;

        public int Matr_FuncFK
        {
            get { return _Matr_FuncFK; }
            set { _Matr_FuncFK = value; }
        }

        private pFuncionario _Funcionario;

        public pFuncionario Funcionario
        {
            get { return _Funcionario; }
            set { _Funcionario = value; }
        }


    }

    public class pDataManu : pManuAr
    {
        private DateTime _Data1;

        public DateTime Data1
        {
            get { return _Data1; }
            set { _Data1 = value; }
        }

        private DateTime _Data2;

        public DateTime Data2
        {
            get { return _Data2; }
            set { _Data2 = value; }
        }


    }

    public class mManuAr
    {
        public void InsManu(pManuAr P)
        {
            Dao D = new Dao();
            D.InsManu(P.Cod_ClienteFK, P.Modelo, P.Marca, P.NumSerie, P.DataEntrada, P.DataSaida, P.Status, P.Observacao, P.ValorMObra, P.FormaPagamento, P.Matr_FuncFK);


        }
        public List<pManuAr> SelManu(int Cod_ClienteFK)
        {
            Dao D = new Dao();
            DataTable DT = D.SelManu(Cod_ClienteFK);
            List<pManuAr> LC = new List<pManuAr>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pManuAr P = new pManuAr();
                P.Cod_Manutencao = Convert.ToInt32(DT.Rows[i]["Cod_Manutencao"]);
                P.Cod_ClienteFK = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]);
                P.Modelo = DT.Rows[i]["Modelo"].ToString();
                P.Marca = DT.Rows[i]["Marca"].ToString();
                P.NumSerie = DT.Rows[i]["NumSerie"].ToString();
                P.DataEntrada = Convert.ToDateTime(DT.Rows[i]["DataEntrada"]);
                P.DataSaida = Convert.ToDateTime(DT.Rows[i]["DataSaida"]);
                P.Status = DT.Rows[i]["Status"].ToString();
                P.Observacao = DT.Rows[i]["Observacao"].ToString();
                P.ValorMObra = Convert.ToDecimal(DT.Rows[i]["ValorMObra"]);
                P.FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString();
                P.Matr_FuncFK = Convert.ToInt32(DT.Rows[i]["Matr_FuncFK"]);
                LC.Add(P);
            }
            return LC;

        }
        public void ExcManuAr(int Cod_Manutencao)
        {
            Dao D = new Dao();
            D.ExcManu(Cod_Manutencao);
        }
        public void AtuManu(pManuAr P)
        {
            Dao D = new Dao();
            D.AtuManu(P.Cod_Manutencao, P.Cod_ClienteFK, P.Modelo, P.Marca, P.NumSerie, P.DataEntrada, P.DataSaida, P.Status, P.Observacao, P.ValorMObra, P.FormaPagamento, P.Matr_FuncFK);
        }
        //public List<pDataPedido> RelatorioVenda(string FormaPagamento, DateTime Data1, DateTime Data2)
        //{
        //    pDataPedido P = new pDataPedido();
        //    DataTable DT = new Dao().RelatorioVenda(FormaPagamento, Data1, Data2);
        //    List<pDataPedido> LC = new List<pDataPedido>();
        //    for (int i = 0; i < DT.Rows.Count; i++)
        //    {
        //        LC.Add(new pDataPedido()
        //        {
        //            Cod_Pedido = Convert.ToInt32(DT.Rows[i]["Cod_Pedido"]),
        //            ValorTotal = Convert.ToDecimal(DT.Rows[i]["ValorTotal"]),
        //            FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString(),
        //            DataPagamento = Convert.ToDateTime(DT.Rows[i]["DataPagamento"]),
        //            Cliente = new pCliente() { Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]), Nome = DT.Rows[i]["Nome"].ToString() }

        //        });
        //    }
        //    return LC;

        //}
        public List<pDataManu> RelatorioManutencaoData(DateTime Data1, DateTime Data2)
        {
            pDataManu P = new pDataManu();
            DataTable DT = new Dao().RelatorioManutencaoData(Data1, Data2);
            List<pDataManu> LC = new List<pDataManu>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                LC.Add(new pDataManu()
               {
                   Cod_Manutencao = Convert.ToInt32(DT.Rows[i]["Cod_Manutencao"]),
                   Cliente = new pCliente() { Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]), Nome = DT.Rows[i]["Nome"].ToString() },
                   //P.Cod_ClienteFK = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]);
                   Modelo = DT.Rows[i]["Modelo"].ToString(),
                   Marca = DT.Rows[i]["Marca"].ToString(),
                   NumSerie = DT.Rows[i]["NumSerie"].ToString(),
                   DataEntrada = Convert.ToDateTime(DT.Rows[i]["DataEntrada"]),
                   DataSaida = Convert.ToDateTime(DT.Rows[i]["DataSaida"]),
                   Status = DT.Rows[i]["Status"].ToString(),
                   Observacao = DT.Rows[i]["Observacao"].ToString(),
                   ValorMObra = Convert.ToDecimal(DT.Rows[i]["ValorMObra"]),
                   FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString(),
                   Matr_FuncFK = Convert.ToInt32(DT.Rows[i]["Matr_FuncFK"])
                   //Funcionario = new pFuncionario() { Matr_Func = Convert.ToInt32(DT.Rows[i]["Matr_FuncFK"]), Nome = DT.Rows[i]["Nome"].ToString() }

               });
            }
            return LC;
        }
        public List<pDataManu> RelatorioManutencaoStatus(string Status)
        {
            pDataManu P = new pDataManu();
            DataTable DT = new Dao().RelatorioManutencaoStatus(Status);
            List<pDataManu> LC = new List<pDataManu>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                LC.Add(new pDataManu()
               {
                   Cod_Manutencao = Convert.ToInt32(DT.Rows[i]["Cod_Manutencao"]),
                   Cliente = new pCliente() { Cod_Cliente = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]), Nome = DT.Rows[i]["Nome"].ToString() },
                   //P.Cod_ClienteFK = Convert.ToInt32(DT.Rows[i]["Cod_ClienteFK"]);
                   Modelo = DT.Rows[i]["Modelo"].ToString(),
                   Marca = DT.Rows[i]["Marca"].ToString(),
                   NumSerie = DT.Rows[i]["NumSerie"].ToString(),
                   DataEntrada = Convert.ToDateTime(DT.Rows[i]["DataEntrada"]),
                   DataSaida = Convert.ToDateTime(DT.Rows[i]["DataSaida"]),
                   Status = DT.Rows[i]["Status"].ToString(),
                   Observacao = DT.Rows[i]["Observacao"].ToString(),
                   ValorMObra = Convert.ToDecimal(DT.Rows[i]["ValorMObra"]),
                   FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString(),
                   Matr_FuncFK = Convert.ToInt32(DT.Rows[i]["Matr_FuncFK"])
                   //Funcionario = new pFuncionario() { Matr_Func = Convert.ToInt32(DT.Rows[i]["Matr_FuncFK"]), Nome = DT.Rows[i]["Nome"].ToString() }

               });
            }
            return LC;
        }
    }
    public class mLogin
    {
        public List<pFuncionario> Login(int Matr_Func, string Senha)
        {
            Dao D = new Dao();
            DataTable DT = D.Login(Matr_Func, Senha);
            List<pFuncionario> LC = new List<pFuncionario>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pFuncionario P = new pFuncionario();
                P.Matr_Func = Convert.ToInt32(DT.Rows[i]["Matr_Func"]);
                P.Nome = DT.Rows[i]["Nome"].ToString();
                P.Rg = DT.Rows[i]["Rg"].ToString();
                P.Cpf = DT.Rows[i]["Cpf"].ToString();
                P.Telefone = DT.Rows[i]["Telefone"].ToString();
                P.Email = DT.Rows[i]["Email"].ToString();
                P.DtNascimento = Convert.ToDateTime(DT.Rows[i]["DTNascimento"]);
                P.Estado = DT.Rows[i]["Estado"].ToString();
                P.Uf = DT.Rows[i]["Uf"].ToString();
                P.Lougradouro = DT.Rows[i]["Lougradouro"].ToString();
                P.Complemento = DT.Rows[i]["Complemento"].ToString();
                P.Bairro = DT.Rows[i]["Bairro"].ToString();
                P.Cep = DT.Rows[i]["Cep"].ToString();
                P.Senha = DT.Rows[i]["Senha"].ToString();
                P.Cargo = DT.Rows[i]["Cargo"].ToString();
                LC.Add(P);
            }
            return LC;

        }

    }

    public class mRelatorio
    {
        public List<pManuAr> RelatorioFinanceiroManu(DateTime DataSaida)
        {
            Dao D = new Dao();
            DataTable DT = D.RelatorioFinanceiroManu(DataSaida);
            List<pManuAr> LC = new List<pManuAr>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pManuAr P = new pManuAr();
                P.Cod_Manutencao = Convert.ToInt32(DT.Rows[i]["Cod_Manutencao"]);
                P.ValorMObra = Convert.ToDecimal(DT.Rows[i]["ValorMObra"]);
                P.FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString();
                LC.Add(P);
            }
            return LC;
        }
        public List<pPedido> RelatorioFinanceiroVenda(DateTime DataPagamento)
        {
            Dao D = new Dao();
            DataTable DT = D.RelatorioFinanceiroVenda(DataPagamento);
            List<pPedido> LC = new List<pPedido>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                pPedido P = new pPedido();
                P.Cod_Pedido = Convert.ToInt32(DT.Rows[i]["Cod_Pedido"]);
                P.ValorTotal = Convert.ToDecimal(DT.Rows[i]["ValorTotal"]);
                P.FormaPagamento = DT.Rows[i]["FormaPagamento"].ToString();
                LC.Add(P);
            }
            return LC;
        }
    }

}




