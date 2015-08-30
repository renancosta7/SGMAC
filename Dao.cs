using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace SlnArCond
{
    public class Dao
    {
        #region Conexao com o banco
        public SqlConnection SqlConn()
        {
            SqlConnection Cn = new SqlConnection();
            string StrConn = @"Data Source = NOTE-PC\SQLEXPRESS; Initial Catalog = ArCon; Integrated Security = True;";
            Cn.ConnectionString = StrConn;
            Cn.Open();
            return Cn;
        }
        #endregion

        #region Manter Cliente
        public void InsCliente(string Nome, string Rg, string Cpf, string Telefone, string Email, DateTime DtNascimento, string Estado, string Uf, string Lougradouro, string Complemento, string Bairro, string Cep)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbCliente (Nome,Rg,Cpf,Telefone,Email,DtNascimento,Estado,Uf,Lougradouro,Complemento,Bairro,Cep)");
            Sb.Append("Values (@Nome,@Rg,@Cpf,@Telefone,@Email,@DtNascimento,@Estado,@Uf,@Lougradouro,@Complemento,@Bairro,@Cep);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Rg", Rg);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DtNascimento", DtNascimento);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Uf", Uf);
            cmd.Parameters.AddWithValue("@Lougradouro", Lougradouro);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Bairro", Bairro);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable SelCliente(string Cpf)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Cliente,Nome,Rg,Cpf,Telefone,Email,DtNascimento,Estado,Uf,Lougradouro,Complemento,Bairro,Cep from tbCliente ");
            Sb.Append("Where Cpf= @Cpf;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;

        }
        public DataTable SelCliente()
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Cliente,Nome from tbCliente ");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;

        }
        public void ExcCliente(string Cpf)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Delete from tbCliente  ");
            Sb.Append("Where Cpf = @Cpf;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.ExecuteNonQuery();
            Cn.Close();

        }
        public void AtuCliente(string Nome, string Rg, string Cpf, string Telefone, string Email, DateTime DtNascimento, string Estado, string Uf, string Lougradouro, string Complemento, string Bairro, string Cep) // isso e um metodo poha não deixe de recordar isso!
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Update tbCliente Set ");
            Sb.Append("Nome = @Nome ,");
            Sb.Append("Rg = @Rg ,");
            Sb.Append("Cpf = @Cpf ,");
            Sb.Append("Telefone = @Telefone ,");
            Sb.Append("Email = @Email ,");
            Sb.Append("DtNascimento = @DtNascimento ,");
            Sb.Append("Estado = @Estado ,");
            Sb.Append("Uf = @Uf ,");
            Sb.Append("Lougradouro = @Lougradouro ,");
            Sb.Append("Complemento = @Complemento ,");
            Sb.Append("Bairro = @Bairro ,");
            Sb.Append("Cep = @Cep ");
            Sb.Append("Where Cpf = @Cpf;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Rg", Rg);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DtNascimento", DtNascimento);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Uf", Uf);
            cmd.Parameters.AddWithValue("@Lougradouro", Lougradouro);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Bairro", Bairro);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.ExecuteNonQuery();
            Cn.Close();

        }
        #endregion

        #region Manter Funcionario
        public void InsFuncionario(string Nome, string Rg, string Cpf, string Telefone, string Email, DateTime DtNascimento, string Estado, string Uf, string Lougradouro, string Complemento, string Bairro, string Cep, string Senha, string Cargo)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbFuncionario (Nome,Rg,Cpf,Telefone,Email,DtNascimento,Estado,Uf,Lougradouro,Complemento,Bairro,Cep,Senha,Cargo)");
            Sb.Append("Values (@Nome,@Rg,@Cpf,@Telefone,@Email,@DtNascimento,@Estado,@Uf,@Lougradouro,@Complemento,@Bairro,@Cep,@Senha,@Cargo);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Rg", Rg);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DtNascimento", DtNascimento);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Uf", Uf);
            cmd.Parameters.AddWithValue("@Lougradouro", Lougradouro);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Bairro", Bairro);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.Parameters.AddWithValue("@Senha", Senha);
            cmd.Parameters.AddWithValue("@Cargo", Cargo);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable SelFuncionario(string Cpf)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Matr_Func,Nome,Rg,Cpf,Telefone,Email,DtNascimento,Estado,Uf,Lougradouro,Complemento,Bairro,Cep,Senha,Cargo from tbFuncionario ");
            Sb.Append("Where Cpf= @Cpf;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;


        }
        public void ExcFuncionario(string Cpf)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Delete from tbFuncionario  ");
            Sb.Append("Where Cpf = @Cpf;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.ExecuteNonQuery();
            Cn.Close();

        }
        public void AtuFuncionario(string Nome, string Rg, string Cpf, string Telefone, string Email, DateTime DtNascimento, string Estado, string Uf, string Lougradouro, string Complemento, string Bairro, string Cep, string Senha, string Cargo) // isso e um metodo poha não deixe de recordar isso!
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Update tbFuncionario Set ");
            Sb.Append("Nome = @Nome ,");
            Sb.Append("Rg = @Rg ,");
            Sb.Append("Cpf = @Cpf ,");
            Sb.Append("Telefone = @Telefone ,");
            Sb.Append("Email = @Email ,");
            Sb.Append("DtNascimento = @DtNascimento ,");
            Sb.Append("Estado = @Estado ,");
            Sb.Append("Uf = @Uf ,");
            Sb.Append("Lougradouro = @Lougradouro ,");
            Sb.Append("Complemento = @Complemento ,");
            Sb.Append("Bairro = @Bairro ,");
            Sb.Append("Cep = @Cep ,");
            Sb.Append("Senha = @Senha ,");
            Sb.Append("Cargo = @Cargo ");
            Sb.Append("Where Cpf = @Cpf;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Rg", Rg);
            cmd.Parameters.AddWithValue("@Cpf", Cpf);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DtNascimento", DtNascimento);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Uf", Uf);
            cmd.Parameters.AddWithValue("@Lougradouro", Lougradouro);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Bairro", Bairro);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.Parameters.AddWithValue("@Senha", Senha);
            cmd.Parameters.AddWithValue("@Cargo", Cargo);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable SelFun()
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Matr_Func,Nome from tbFuncionario ");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;


        }
        #endregion

        #region Manter fornecedor

        public void InsFornecedor(string Razao_Social, string Cnpj, string Telefone, string Email, string Tipo_Peca, string Estado, string Uf, string Lougradouro, string Complemento, string Bairro, string Cep)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbFornecedor (Razao_Social,Cnpj,Telefone,Email,Tipo_Peca,Estado,Uf,Lougradouro,Complemento,Bairro,Cep)");
            Sb.Append("Values (@Razao_Social,@Cnpj,@Telefone,@Email,@Tipo_Peca,@Estado,@Uf,@Lougradouro,@Complemento,@Bairro,@Cep);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Razao_Social", Razao_Social);
            cmd.Parameters.AddWithValue("@Cnpj", Cnpj);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Tipo_Peca", Tipo_Peca);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Uf", Uf);
            cmd.Parameters.AddWithValue("@Lougradouro", Lougradouro);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Bairro", Bairro);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable SelFornecedor(string Cnpj)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Fornecedor,Razao_Social,Cnpj,Telefone,Email,Tipo_Peca,Estado,Uf,Lougradouro,Complemento,Bairro,Cep From tbFornecedor ");
            Sb.Append("Where Cnpj=@Cnpj;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cnpj", Cnpj);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;


        }
        public DataTable SelFornecedor()
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Fornecedor,Razao_Social,Tipo_Peca From tbFornecedor ");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;


        }
        public void ExcFornecedor(string Cnpj)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Delete from tbFornecedor  ");
            Sb.Append("Where Cnpj = @Cnpj;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cnpj", Cnpj);
            cmd.ExecuteNonQuery();
            Cn.Close();

        }
        public void AtuFornecedor(string Razao_Social, string Cnpj, string Telefone, string Email, string Tipo_Peca, string Estado, string Uf, string Lougradouro, string Complemento, string Bairro, string Cep)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Update tbFornecedor Set ");
            Sb.Append("Razao_Social = @Razao_Social ,");
            Sb.Append("Telefone = @Telefone ,");
            Sb.Append("Email = @Email ,");
            Sb.Append("Tipo_Peca = @Tipo_Peca ,");
            Sb.Append("Estado = @Estado ,");
            Sb.Append("Uf = @Uf ,");
            Sb.Append("Lougradouro = @Lougradouro ,");
            Sb.Append("Complemento = @Complemento ,");
            Sb.Append("Bairro = @Bairro ,");
            Sb.Append("Cep = @Cep ");
            Sb.Append("Where Cnpj = @Cnpj;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Razao_Social", Razao_Social);
            cmd.Parameters.AddWithValue("@Cnpj", Cnpj);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Tipo_Peca", Tipo_Peca);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Uf", Uf);
            cmd.Parameters.AddWithValue("@Lougradouro", Lougradouro);
            cmd.Parameters.AddWithValue("@Complemento", Complemento);
            cmd.Parameters.AddWithValue("@Bairro", Bairro);
            cmd.Parameters.AddWithValue("@Cep", Cep);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }

        #endregion

        #region Manter peças
        public void InsPecas(string Descricao, string Fabricante, string Modelo, decimal Valor_Entrada, decimal Valor_Saida, int Quantidade, int Cod_FornecedorFK)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbPecas (Descricao,Fabricante,Modelo,Valor_Entrada,Valor_Saida,Quantidade,Cod_FornecedorFK) ");
            Sb.Append("Values (@Descricao,@Fabricante,@Modelo,@Valor_Entrada,@Valor_Saida,@Quantidade,@Cod_FornecedorFK);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Descricao", Descricao);
            cmd.Parameters.AddWithValue("@Fabricante", Fabricante);
            cmd.Parameters.AddWithValue("@Modelo", Modelo);
            cmd.Parameters.AddWithValue("@Valor_Entrada", Valor_Entrada);
            cmd.Parameters.AddWithValue("@Valor_Saida", Valor_Saida);
            cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
            cmd.Parameters.AddWithValue("@Cod_FornecedorFK", Cod_FornecedorFK);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable SelRepeater()
        {
            
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Pecas,Descricao,Fabricante,Modelo,Valor_Entrada,Valor_Saida,Quantidade From tbPecas Where Quantidade>'0' ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        public DataTable SelItens(string Descricao)
        {

            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Pecas,Descricao,Fabricante,Modelo,Valor_Entrada,Valor_Saida,Quantidade From tbPecas Where Quantidade>'0' and Descricao Like @Descricao ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Descricao", "%" + Descricao.Trim().Replace(" ", "%") + "%");
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        public DataTable SelPecas(int Cod_Pecas)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Pecas,Descricao,Fabricante,Modelo,Valor_Entrada,Valor_Saida,Quantidade From tbPecas ");
            if (Cod_Pecas > 0)
            {
                Sb.Append("Where Cod_Pecas=@Cod_Pecas;");
            }
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cod_Pecas", Cod_Pecas);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        public DataTable SelPecas()
        {
            return SelPecas(0);
        }
        public void ExcPecas(int Cod_Pecas)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Delete from tbPecas  ");
            Sb.Append("Where Cod_Pecas = @Cod_Pecas;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cod_Pecas", Cod_Pecas);
            cmd.ExecuteNonQuery();
            Cn.Close();

        }
        public void AtuPecas(int Cod_Pecas, string Descricao, string Fabricante, string Modelo, decimal Valor_Entrada, decimal Valor_Saida, int Quantidade)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Update tbPecas Set ");
            Sb.Append("Descricao = @Descricao ,");
            Sb.Append("Fabricante = @Fabricante ,");
            Sb.Append("Modelo = @Modelo ,");
            Sb.Append("Valor_Entrada = @Valor_Entrada ,");
            Sb.Append("Valor_Saida = @Valor_Saida ,");
            Sb.Append("Quantidade = @Quantidade ");
            Sb.Append("Where Cod_Pecas = @Cod_Pecas;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Descricao", Descricao);
            cmd.Parameters.AddWithValue("@Fabricante", Fabricante);
            cmd.Parameters.AddWithValue("@Modelo", Modelo);
            cmd.Parameters.AddWithValue("@Valor_Entrada", Valor_Entrada);
            cmd.Parameters.AddWithValue("@Valor_Saida", Valor_Saida);
            cmd.Parameters.AddWithValue("@Quantidade", Quantidade);
            cmd.Parameters.AddWithValue("@Cod_Pecas", Cod_Pecas);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public void VendPecas(int Cod_Pecas, int pQuantidade)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Update tbPecas Set ");
            Sb.Append("Quantidade = Quantidade - @pQuantidade ");
            Sb.Append("where Cod_Pecas = @Cod_Pecas;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@pQuantidade", pQuantidade);
            cmd.Parameters.AddWithValue("@Cod_Pecas", Cod_Pecas);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public void InsPedido(decimal ValorTotal, string FormaPagamento, DateTime DataPagamento, int Cod_ClienteFK, int Matr_FuncFK)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbPedido (ValorTotal,FormaPagamento,DataPagamento,Cod_ClienteFK,Matr_FuncFK) ");
            Sb.Append("Values (@ValorTotal,@FormaPagamento,@DataPagamento,@Cod_ClienteFK,@Matr_FuncFK);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@ValorTotal", ValorTotal);
            cmd.Parameters.AddWithValue("@FormaPagamento", FormaPagamento);
            cmd.Parameters.AddWithValue("@DataPagamento", DataPagamento);
            cmd.Parameters.AddWithValue("@Cod_ClienteFK", Cod_ClienteFK);
            cmd.Parameters.AddWithValue("@Matr_FuncFK", Matr_FuncFK);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public void InsItemPedido(int Cod_Pecas, string Descricao, decimal Valor_Saida, int pQuantidade, decimal Total, int Cod_Pedido)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbItemPedido (Cod_PecasFK,Descricao,Valor_Saida,Quantidade,Total,Cod_PedidoFK) ");
            Sb.Append("Values (@Cod_PecasFK,@Descricao,@Valor_Saida,@Quantidade,@Total,@Cod_PedidoFK);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cod_PecasFK", Cod_Pecas);
            cmd.Parameters.AddWithValue("@Descricao", Descricao);
            cmd.Parameters.AddWithValue("@Valor_Saida", Valor_Saida);
            cmd.Parameters.AddWithValue("@Quantidade", pQuantidade);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Cod_PedidoFK", Cod_Pedido);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable RelatorioVenda(string FormaPagamento,DateTime Data1, DateTime Data2)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select P.Cod_Pedido,P.ValorTotal,P.FormaPagamento,P.DataPagamento,P.Cod_ClienteFK,C.Nome From tbPedido P Inner Join tbCliente C On C.Cod_Cliente = P.Cod_ClienteFK WHERE FormaPagamento=@FormaPagamento and DataPagamento BETWEEN @Data1 and @Data2 ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@FormaPagamento", FormaPagamento);
            cmd.Parameters.AddWithValue("@Data1", Data1);
            cmd.Parameters.AddWithValue("@Data2", Data2);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }

        public DataTable RelatorioVendaFunc(string FormaPagamento, DateTime Data1, DateTime Data2,int Matr_FuncFK)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select P.Cod_Pedido,P.ValorTotal,P.FormaPagamento,P.DataPagamento,P.Cod_ClienteFK,P.Matr_FuncFK,C.Nome From tbPedido P Inner Join tbCliente C On C.Cod_Cliente = P.Cod_ClienteFK WHERE FormaPagamento=@FormaPagamento and Matr_FuncFK=@Matr_FuncFK and DataPagamento BETWEEN @Data1 and @Data2 ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@FormaPagamento", FormaPagamento);
            cmd.Parameters.AddWithValue("@Data1", Data1);
            cmd.Parameters.AddWithValue("@Data2", Data2);
            cmd.Parameters.AddWithValue("@Matr_FuncFK", Matr_FuncFK);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        public DataTable SelecionarVenda(int Cod_Pedido)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_PecasFK,Descricao,Valor_Saida,Quantidade,Total From tbItemPedido WHERE Cod_PedidoFK = @Cod_Pedido;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cod_Pedido", Cod_Pedido);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        #endregion

        #region ManterAr
        public void InsManu(int Cod_ClienteFK, string Modelo, string Marca, string NumSerie, DateTime DataEntrada, DateTime DataSaida, string Status, string Observacao, decimal ValorMObra, string FormaPagamento, int Matr_FuncFK)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Insert into tbManuAr (Cod_ClienteFK,Modelo,Marca,NumSerie,DataEntrada,DataSaida,Status,Observacao,ValorMObra,FormaPagamento,Matr_FuncFK) ");
            Sb.Append("Values (@Cod_ClienteFK,@Modelo,@Marca,@NumSerie,@DataEntrada,@DataSaida,@Status,@Observacao,@ValorMObra,@FormaPagamento,@Matr_FuncFK);");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cod_ClienteFK", Cod_ClienteFK);
            cmd.Parameters.AddWithValue("@Modelo", Modelo);
            cmd.Parameters.AddWithValue("@Marca", Marca);
            cmd.Parameters.AddWithValue("@NumSerie", NumSerie);
            cmd.Parameters.AddWithValue("@DataEntrada", DataEntrada);
            cmd.Parameters.AddWithValue("@DataSaida", DataSaida);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Observacao", Observacao);
            cmd.Parameters.AddWithValue("@ValorMObra", ValorMObra);
            cmd.Parameters.AddWithValue("@FormaPagamento", FormaPagamento);
            cmd.Parameters.AddWithValue("@Matr_FuncFK", Matr_FuncFK);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable SelManu(int Cod_ClienteFK)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Cod_Manutencao,Cod_ClienteFK,Modelo,Marca,NumSerie,DataEntrada,DataSaida,Status,Observacao,ValorMObra,FormaPagamento,Matr_FuncFK from tbManuAr ");
            Sb.Append("Where Cod_ClienteFK=@Cod_ClienteFK;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cod_ClienteFK", Cod_ClienteFK);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;

        }
        public void ExcManu(int Cod_Manutencao)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Delete from tbManuAr  ");
            Sb.Append("Where Cod_Manutencao = @Cod_Manutencao;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cod_Manutencao", Cod_Manutencao);
            cmd.ExecuteNonQuery();
            Cn.Close();

        }
        public void AtuManu(int Cod_Manutencao, int Cod_ClienteFK, string Modelo, string Marca, string NumSerie, DateTime DataEntrada, DateTime DataSaida, string Status, string Observacao, decimal ValorMObra, string FormaPagamento, int Matr_FuncFK)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Update tbManuAr Set ");
            Sb.Append("Cod_ClienteFK = @Cod_ClienteFK ,");
            Sb.Append("Modelo = @Modelo ,");
            Sb.Append("Marca = @Marca ,");
            Sb.Append("NumSerie = @NumSerie ,");
            Sb.Append("DataEntrada = @DataEntrada ,");
            Sb.Append("DataSaida = @DataSaida ,");
            Sb.Append("Status = @Status ,");
            Sb.Append("Observacao = @Observacao ,");
            Sb.Append("ValorMObra = @ValorMObra ,");
            Sb.Append("FormaPagamento = @FormaPagamento ,");
            Sb.Append("Matr_FuncFK = @Matr_FuncFK ");
            Sb.Append("Where Cod_Manutencao = @Cod_Manutencao;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            cmd.Parameters.AddWithValue("@Cod_ClienteFK", Cod_ClienteFK);
            cmd.Parameters.AddWithValue("@Modelo", Modelo);
            cmd.Parameters.AddWithValue("@Marca", Marca);
            cmd.Parameters.AddWithValue("@NumSerie", NumSerie);
            cmd.Parameters.AddWithValue("@DataEntrada", DataEntrada.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@DataSaida", DataSaida.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Observacao", Observacao);
            cmd.Parameters.AddWithValue("@ValorMObra", ValorMObra);
            cmd.Parameters.AddWithValue("@FormaPagamento", FormaPagamento);
            cmd.Parameters.AddWithValue("@Matr_FuncFK", Matr_FuncFK);
            cmd.Parameters.AddWithValue("@Cod_Manutencao", Cod_Manutencao);
            cmd.ExecuteNonQuery();
            Cn.Close();
        }
        public DataTable RelatorioManutencaoData(DateTime Data1, DateTime Data2)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select P.Cod_Manutencao,P.Cod_ClienteFK,C.Nome,P.Modelo,P.Marca,P.NumSerie,P.DataEntrada,P.DataSaida,P.Status,P.Observacao,P.ValorMObra,P.FormaPagamento,P.Matr_FuncFK from tbManuAr P Inner Join tbCliente C On C.Cod_Cliente = P.Cod_ClienteFK WHERE DataEntrada BETWEEN @Data1 and @Data2;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Data1", Data1);
            cmd.Parameters.AddWithValue("@Data2", Data2);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        public DataTable RelatorioManutencaoStatus(string Status)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select P.Cod_Manutencao,P.Cod_ClienteFK,C.Nome,P.Modelo,P.Marca,P.NumSerie,P.DataEntrada,P.DataSaida,P.Status,P.Observacao,P.ValorMObra,P.FormaPagamento,P.Matr_FuncFK from tbManuAr P Inner Join tbCliente C On C.Cod_Cliente = P.Cod_ClienteFK WHERE Status=@Status ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Status", Status);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }


        #endregion

        #region Login

        public DataTable Login(int Matr_Func, string Senha)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("Select Matr_Func,Nome,Rg,Cpf,Telefone,Email,DtNascimento,Estado,Uf,Lougradouro,Complemento,Bairro,Cep,Senha,Cargo from tbFuncionario where Matr_Func = @Matr_Func and Senha = @Senha ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Matr_Func", Matr_Func);
            cmd.Parameters.AddWithValue("@Senha", Senha);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;


        }

        #endregion


        public DataTable RelatorioFinanceiroManu(DateTime DataSaida)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("select Cod_Manutencao,ValorMobra,FormaPagamento from tbManuAr where Status='Concluido' and DataSaida=@DataSaida ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DataSaida", DataSaida);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }
        public DataTable RelatorioFinanceiroVenda(DateTime DataPagamento)
        {
            SqlConnection Cn = SqlConn();
            StringBuilder Sb = new StringBuilder();
            Sb.Append("select Cod_Pedido,ValorTotal,FormaPagamento from tbPedido where DataPagamento=@DataPagamento ;");
            SqlCommand cmd = new SqlCommand(Sb.ToString(), Cn);
            SqlDataAdapter Adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DataPagamento", DataPagamento);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            cmd.ExecuteScalar();
            Cn.Close();
            return Dt;
        }

    }
}
