using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace NavEventos.Class
{

    #region CONEXAO
    public class cConexao
    {
        private static OleDbConnection con = null;

        // Abre a Conexão
        public static OleDbConnection abre_conexao()
        {
            con = new OleDbConnection(string.Concat(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString, ";Jet OLEDB:Database Password=gr@w*16"));
            //con = new OleDbConnection(string.Concat(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString));
            try
            {
                con.Open();
            }
            catch (OleDbException ex)
            {
                con = null;
               
            }
            return con;
        }

        //fecha conexão
        public static void fecha_conexao()
        {
            if (con != null)
            {
                con.Dispose();
                con.Close();
            }
        }
    }

    #endregion

    #region EVENTO
    public class cEvento
    {
        #region PROPERTIES
        public int id_evento { get; set; }
        public int id_seq_evento { get; set; }
        public int id_setor { get; set; }
        public int status { get; set; }
        public int id_cliente { get; set; }
        public int id_fundoOrigem { get; set; }
        public int id_fundoDestino { get; set; }
        public int id_produto { get; set; }
        public string ContatoCliente { get; set; }
        public string descricao_evento { get; set; }
        public string rtxtHistorico { get; set; }
        public string rtxtComentario { get; set; }
        public string ApCad { get; set; }
        public string ApCadData { get; set; }
        public string ApGov { get; set; }
        public string ApGovData { get; set; }
        public string ApCap { get; set; }
        public string ApCapData { get; set; }
        public string ApRTO { get; set; }
        public string ApRTOData { get; set; }
        public string comentario { get; set; }
        public string flag { get; set; }
        public bool flagCapacity { get; set; }
        public bool extra_pauta { get; set; }
        public bool excecao { get; set; }
        public string nrRTO { get; set; }

        #endregion

        #region PEGA O PRÓXIMO NÚMERO PARA O EVENTO
        public int insert_sequencia_evento()
        {
            int nret = 0;
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO SEQ_EVENTO_TB (USERLOG,DTCAD) " +
                                "VALUES('" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    nret = cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return nret;
        }
        public int select_sequencia_evento()
        {
            int retseq = 0;
            try
            {
                cGlobal.query = "SELECT MAX(SEQ_EVENTO) + 1 AS ID_SEQ_EVENTO FROM EVENTO_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retseq =Convert.ToInt32(dr["ID_SEQ_EVENTO"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }
                return retseq;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void remove_sequencia_evento(int seq, string user)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM SEQ_EVENTO_TB WHERE ID_SEQ_EVENTO = " + seq + " AND USERLOG = '" + cGlobal.userlogado + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        #endregion

        public int grava_evento(cEvento ce)
        {
            int valret = 0;
            try
            {
                cGlobal.query = "SELECT COUNT(*) AS EXISTE FROM EVENTO_TB WHERE SEQ_EVENTO = " + ce.id_seq_evento;
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            valret = Convert.ToInt32(dr["EXISTE"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }
                if (valret == 0)
                {
                #region INSERT
                cGlobal.query = "INSERT INTO EVENTO_TB (SEQ_EVENTO," +
                                                       "ID_STATUS," +
                                                       "ID_CLIENTE," +
                                                       "HISTORICO," +
                                                       "COMENTARIOS," +
                                                       "USER_CAD," +
                                                       "DT_USER_CAD, " +
                                                       "FLAG, " +
                                                       "FLAG_CAPACITY," +
                                                       "ID_FUNDO_ORIGEM," +
                                                       "ID_FUNDO_DESTINO," +
                                                       "ID_PRODUTO," +
                                                       "EXTRAPAUTA," +
                                                       "EXCECAO," +
                                                       "NRO_RTO)" +
                                " VALUES (" + ce.id_seq_evento + ", " +
                                       "" + ce.status + ", " +
                                       "" + ce.id_cliente + ", " +
                                       "'" + ce.rtxtHistorico + "', " +
                                      "'" + ce.rtxtComentario + "', " +
                                      "'" + ce.ApCad + "', " +
                                      "'" + DateTime.Now + "', " +
                                      "'" + ce.flag + "', " +
                                      "" + ce.flagCapacity + ",";
                                if (ce.id_fundoOrigem == 1)
                                    cGlobal.query += " NULL, ";
                                else
                                    cGlobal.query += "" + ce.id_fundoOrigem + "," ;

                                if (!string.IsNullOrEmpty(ce.id_fundoDestino.ToString()))
                                {
                                    if (ce.id_fundoDestino != 1)
                                    {
                                        cGlobal.query += "" + ce.id_fundoDestino + ", ";
                                    }
                                    else
                                    {
                                        cGlobal.query += " NULL, ";
                                    }
                                }
                                else
                                {
                                    cGlobal.query += " NULL, ";
                                }

                                cGlobal.query += "" + ce.id_produto + ", " +
                                                        "" + ce.extra_pauta + ", " +
                                                        "" + ce.excecao + ", ";
                                        
                                if (string.IsNullOrEmpty(ce.nrRTO))
                                {
                                   cGlobal.query += " NULL )";
                                } 
                                else
                                {
                                    cGlobal.query += ce.nrRTO + " ) ";
                                }
                                    
               
                    #endregion
                }
                else
                {
                    #region UPDATE
                    cGlobal.query = "UPDATE EVENTO_TB ";
                    cGlobal.query += " SET ";
                    cGlobal.query += "  EVENTO_TB.COMENTARIOS = '" + ce.comentario + "'";
                    cGlobal.query += " ,EVENTO_TB.ID_CLIENTE = " + ce.id_cliente ; 
                    cGlobal.query += " ,EVENTO_TB.HISTORICO = '" + ce.rtxtHistorico + "'";
                    cGlobal.query += " ,EVENTO_TB.FLAG = '" + ce.flag + "'";
                    cGlobal.query += " ,EVENTO_TB.FLAG_CAPACITY =  " + ce.flagCapacity  ;
                    if (!string.IsNullOrEmpty(ce.id_produto.ToString()) && ce.id_produto != 1)
                    { 
                        cGlobal.query += " ,EVENTO_TB.ID_PRODUTO = " + ce.id_produto;
                    }
                    if (!string.IsNullOrEmpty(ce.id_fundoOrigem.ToString()) && ce.id_fundoOrigem != 1)
                    { 
                        cGlobal.query += " ,EVENTO_TB.ID_FUNDO_ORIGEM = " + ce.id_fundoOrigem;
                    }
                    if (!string.IsNullOrEmpty(ce.id_fundoDestino.ToString()) && ce.id_fundoDestino != 1)
                    {
                        cGlobal.query += " ,EVENTO_TB.ID_FUNDO_DESTINO = " + ce.id_fundoDestino;
                    }
                    cGlobal.query += " ,EVENTO_TB.EXTRAPAUTA = " + ce.extra_pauta;
                    cGlobal.query += " ,EVENTO_TB.EXCECAO = " + ce.excecao;
                    cGlobal.query += " ,EVENTO_TB.NRO_RTO = " + (string.IsNullOrEmpty(ce.nrRTO)?"NULL":ce.nrRTO);
                    cGlobal.query += " WHERE SEQ_EVENTO = " + ce.id_seq_evento;




                    #endregion
                }

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    valret = cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return valret;
        }
        public void remove_evento(int seq)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq ;
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet eventos(string param, bool pesq)
        {
            DataSet dst = new DataSet();
            
            dst.Clear();
            try
            {
                #region QUERY 1 EVENTO_TB
                if (!pesq)
                {
                    cGlobal.query = "SELECT * FROM EVENTO_TB ORDER BY SEQ_EVENTO DESC ";
                }
                else
                {
                    #region PESQUISA CONFORME PARAMETRO
                    if (acha_fundo(param))
                    {
                        cGlobal.query = "SELECT " +
                                        "TB1.* " +
                                        "FROM EVENTO_TB TB1, STATUS_TB TB2, CLIENTE_TB TB3, FUNDO_TB TB4, PRODUTO_TB TB5 " +
                                        "WHERE TB1.ID_STATUS = TB2.ID_STATUS " +
                                        "AND TB1.ID_CLIENTE = TB3.ID_CLIENTE " +
                                        "AND TB1.ID_FUNDO = TB4.ID_FUNDO " +
                                        "AND TB1.ID_PRODUTO = TB5.ID_PRODUTO " +
                                        "AND TB4.RAZAO_SOCIAL LIKE '%" + param + "%' " ;
                    }
                    else if (acha_cliente(param))
                    {
                        cGlobal.query = "SELECT " +
                                        "TB1.* " +
                                        "FROM EVENTO_TB TB1, STATUS_TB TB2, CLIENTE_TB TB3, FUNDO_TB TB4, PRODUTO_TB TB5 " +
                                        "WHERE TB1.ID_STATUS = TB2.ID_STATUS " +
                                        "AND TB1.ID_CLIENTE = TB3.ID_CLIENTE " +
                                        "AND TB1.ID_FUNDO = TB4.ID_FUNDO " +
                                        "AND TB1.ID_PRODUTO = TB5.ID_PRODUTO " +
                                        "AND TB3.CLIENTE LIKE '%" + param + "%' ";
                    }
                    else if (acha_status(param))
                    {
                        cGlobal.query = "SELECT " +
                                        "TB1.* " +
                                        "FROM EVENTO_TB TB1, STATUS_TB TB2, CLIENTE_TB TB3, FUNDO_TB TB4, PRODUTO_TB TB5 " +
                                        "WHERE TB1.ID_STATUS = TB2.ID_STATUS " +
                                        "AND TB1.ID_CLIENTE = TB3.ID_CLIENTE " +
                                        "AND TB1.ID_FUNDO = TB4.ID_FUNDO " +
                                        "AND TB1.ID_PRODUTO = TB5.ID_PRODUTO " +
                                        "AND TB2.STATUS LIKE '%" + param + "%' ";
                    }
                    else if (acha_produto(param))
                    {
                        cGlobal.query = "SELECT " +
                                        "TB1.* " +
                                        "FROM EVENTO_TB TB1, STATUS_TB TB2, CLIENTE_TB TB3, FUNDO_TB TB4, PRODUTO_TB TB5 " +
                                        "WHERE TB1.ID_STATUS = TB2.ID_STATUS " +
                                        "AND TB1.ID_CLIENTE = TB3.ID_CLIENTE " +
                                        "AND TB1.ID_FUNDO = TB4.ID_FUNDO " +
                                        "AND TB1.ID_PRODUTO = TB5.ID_PRODUTO " +
                                         "AND TB5.PRODUTO LIKE '%" + param + "%'";
                    }
                    else if (acha_codigo_evento(param))
                    {
                        cGlobal.query = "SELECT " +
                                        "TB1.* " +
                                        "FROM EVENTO_TB TB1, STATUS_TB TB2, CLIENTE_TB TB3, FUNDO_TB TB4, PRODUTO_TB TB5 " +
                                        "WHERE TB1.ID_STATUS = TB2.ID_STATUS " +
                                        "AND TB1.ID_CLIENTE = TB3.ID_CLIENTE " +
                                        "AND TB1.ID_FUNDO = TB4.ID_FUNDO " +
                                        "AND TB1.ID_PRODUTO = TB5.ID_PRODUTO " +
                                        "AND TB1.SEQ_EVENTO = " + param ;
                    }
                    #endregion
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Eventoreg");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 2 STATUS_TB
                cGlobal.query = "SELECT * FROM STATUS_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Statusreg");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 3 CLIENTE_TB 
                cGlobal.query = "SELECT ID_CLIENTE,UCASE(CLIENTE) AS CLIENTE FROM CLIENTE_TB ORDER BY CLIENTE ASC ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Clientereg");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 4 Origem FUNDO_TB
                cGlobal.query = "SELECT * FROM FUNDO_TB ORDER BY 1 ASC ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "FundoOrigemreg");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 4 Destino FUNDO_TB
                cGlobal.query = "SELECT * FROM FUNDO_TB ORDER BY 1 ASC ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "FundoDestinoreg");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 5 PRODUTO_TB
                cGlobal.query = "SELECT * FROM PRODUTO_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Produtoreg");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region RELACIONANDO DATASET
                dst.Relations.Clear();
                dst.Relations.Add("A", dst.Tables["Statusreg"].Columns["ID_STATUS"], dst.Tables["Eventoreg"].Columns["ID_STATUS"], false);
                dst.Relations.Add("B", dst.Tables["Clientereg"].Columns["ID_CLIENTE"], dst.Tables["Eventoreg"].Columns["ID_CLIENTE"], false);
                dst.Relations.Add("C", dst.Tables["FundoOrigemreg"].Columns["ID_FUNDO"], dst.Tables["Eventoreg"].Columns["ID_FUNDO_ORIGEM"], false);
                dst.Relations.Add("D", dst.Tables["Produtoreg"].Columns["ID_PRODUTO"], dst.Tables["Eventoreg"].Columns["ID_PRODUTO"], false);
                dst.Relations.Add("E", dst.Tables["FundoDestinoreg"].Columns["ID_FUNDO"], dst.Tables["Eventoreg"].Columns["ID_FUNDO_DESTINO"], false);
                #endregion

                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_setor_evento(cEvento ce)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT * FROM REL_EVENTO_SETOR_TB, SETOR_TB WHERE SETOR_TB.ID_SETOR = REL_EVENTO_SETOR_TB.ID_SETOR AND SEQ_EVENTO = " + ce.id_seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "SetorEvento");
                    }
                }
                #endregion

                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_tipo_evento(cEvento ce)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY 
                cGlobal.query = "SELECT * FROM DESCRICAO_EVENTO_TB, TIPO_EVENTO_TB WHERE TIPO_EVENTO_TB.ID_TP_EVENTO = DESCRICAO_EVENTO_TB.ID_TP_EVENTO AND SEQ_EVENTO = " + ce.id_seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "TipoEvento");
                    }
                }
                #endregion
                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_dados_fundo_origem(cEvento ce)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY 
                cGlobal.query = "SELECT EVENTO_TB.SEQ_EVENTO,FUNDO_TB.SIGLA_SAC, FUNDO_TB.SIGLA_FY, FUNDO_TB.CNPJ_CPF, FUNDO_TB.RAZAO_SOCIAL FROM EVENTO_TB, FUNDO_TB " +
                                "WHERE EVENTO_TB.ID_FUNDO_ORIGEM = FUNDO_TB.ID_FUNDO " +
                                "AND SEQ_EVENTO = " + ce.id_seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "DadosFundoOrigem");
                    }
                }
                #endregion
                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int atualiza_comentario(cEvento ce, string tipo)
        {
            int valRetorno = 0;
            string coluna;
            if (tipo.Equals("HISTORICO"))
                coluna = "HISTORICO";
            else
            {
                coluna = "COMENTARIOS";
            }
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE EVENTO_TB SET " + coluna + " = '" + ce.comentario + "' WHERE SEQ_EVENTO = " + ce.id_seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    valRetorno = cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return valRetorno;
        }

        public DataTable tipo_evento(cEvento ce)
        {
            try
            {
                DataTable dt = new DataTable();
                cGlobal.query = "SELECT TIPO_EVENTO_TB.EVENTO, DESCRICAO_EVENTO_TB.*, DESCRICAO_EVENTO_TB.CDPASSIVO AS CDPASSIVO, DESCRICAO_EVENTO_TB.CDATIVO AS CDATIVO, " +
                                " TB_ATIVO.DESCRICAO AS DESCRICAO_ATIVO, TB_PASSIVO.DESCRICAO AS DESCRICAO_PASSIVO " +
                                " FROM DESCRICAO_EVENTO_TB, TIPO_EVENTO_TB, TAMANHO_TB AS TB_ATIVO, TAMANHO_TB AS TB_PASSIVO " +
                                " WHERE TIPO_EVENTO_TB.ID_TP_EVENTO = DESCRICAO_EVENTO_TB.ID_TP_EVENTO " +
                                " AND   DESCRICAO_EVENTO_TB.SEQ_EVENTO = " + ce.id_seq_evento +
                                " AND   TB_ATIVO.CDTAMANHO = DESCRICAO_EVENTO_TB.CDATIVO " +
                                " AND   TB_PASSIVO.CDTAMANHO = DESCRICAO_EVENTO_TB.CDPASSIVO ";
                                
                using (OleDbDataAdapter da = new OleDbDataAdapter(cGlobal.query, cConexao.abre_conexao()))
                {
                    da.Fill(dt);
                }
                cConexao.fecha_conexao();
                return dt;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

       

        public int atualiza_status_evento(cEvento ce, int nivel)
        {
            int valret = 0;
            try
            {
                #region QUERY
                if (nivel == 0) //GOVERNANÇA
                {
                    cGlobal.query = "UPDATE EVENTO_TB SET ID_STATUS = 3, " +
                                                         "GOV_CAD = '" + cGlobal.userlogado + "', " +
                                                         "DT_GOV_CAD = '" + DateTime.Now + "' " +
                                    "WHERE SEQ_EVENTO = " + ce.id_seq_evento + " ";
                }
                if (nivel == 1) //CAPACITY
                {
                    cGlobal.query = "UPDATE EVENTO_TB SET ID_STATUS = 4, " +
                                                         "CAPACITY_CAD = '" + cGlobal.userlogado + "', " +
                                                         "DT_CAPACITY_CAD = '" + DateTime.Now + "' " +
                                    "WHERE SEQ_EVENTO = " + ce.id_seq_evento + " ";
                }
                if (nivel == 2) //SUPORTE
                {
                    cGlobal.query = "UPDATE EVENTO_TB SET ID_STATUS = " + ce.status + ", " +
                                                         "RTO_CAD = '" + cGlobal.userlogado + "', " +
                                                         "DT_RTO_CAD = '" + DateTime.Now + "' " +
                                    "WHERE SEQ_EVENTO = " + ce.id_seq_evento + " ";
                }
                if (nivel == 3) //RESERVA CAPACITY
                {
                    cGlobal.query = "UPDATE EVENTO_TB SET ID_STATUS = 10, " +
                                                         "CAPACITY_CAD = '" + cGlobal.userlogado + "', " +
                                                         "DT_CAPACITY_CAD = '" + DateTime.Now + "' " +
                                    "WHERE SEQ_EVENTO = " + ce.id_seq_evento + " ";
                }
                if (nivel == 4) //AGENDADO
                {
                    cGlobal.query = "UPDATE EVENTO_TB SET ID_STATUS = 5, " +
                                                         "RTO_CAD = '" + cGlobal.userlogado + "', " +
                                                         "DT_RTO_CAD = '" + DateTime.Now + "' " +
                                    "WHERE SEQ_EVENTO = " + ce.id_seq_evento + " ";
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    valret = cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return valret;
        }

        public int verifica_aprov_suporte(int seq_evento)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq_evento + " AND RTO_CAD IS NOT NULL AND DT_RTO_CAD IS NOT NULL  ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                #endregion

                return cGlobal.existline;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int verifica_aprov_governanca(int seq_evento)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq_evento + " AND GOV_CAD IS NOT NULL AND DT_GOV_CAD IS NOT NULL  ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                #endregion

                return cGlobal.existline;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int verifica_aprov_capacity(int seq_evento)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq_evento + " AND CAPACITY_CAD IS NOT NULL AND DT_CAPACITY_CAD IS NOT NULL  ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                #endregion

                return cGlobal.existline;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataTable retorna_demandas()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                cGlobal.query = "SELECT " +
                                "EVENTO_TB.SEQ_EVENTO, " +
                                "STATUS_TB.STATUS, " +
                                "USER_CAD & ' - ' & DT_USER_CAD AS DEMANDA," +
                                "GOV_CAD & ' - ' & DT_GOV_CAD AS GOVERNANCA, " +
                                "CAPACITY_CAD & ' - ' & DT_CAPACITY_CAD AS CAPACITY, " +
                                "RTO_CAD & ' - ' & DT_RTO_CAD AS RTO " +
                                "FROM EVENTO_TB, STATUS_TB " +
                                "WHERE EVENTO_TB.ID_STATUS = STATUS_TB.ID_STATUS " +
                                "ORDER BY EVENTO_TB.SEQ_EVENTO DESC ";
                using (OleDbDataAdapter da = new OleDbDataAdapter(cGlobal.query, cConexao.abre_conexao()))
                {
                    da.Fill(dt);
                }
                cConexao.fecha_conexao();
                dt.Dispose();
                return dt;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int atualiza_descricao_evento(bool reserva, string status, int id_desc_evento, int seq_evento, int id_tp_evento)
        {
            int valret = 0;
            try
            {
                #region QUERY
                if (reserva)
                {
                    cGlobal.query = "UPDATE DESCRICAO_EVENTO_TB SET STATUS = '" + status + "' " +
                                    "WHERE SEQ_EVENTO = " + seq_evento + " ";
                }
                else
                {
                    cGlobal.query = "UPDATE DESCRICAO_EVENTO_TB SET STATUS = '" + status + "' " +
                                "WHERE ID_DESCRICAO_EVENTO = " + id_desc_evento + " " +
                                "AND SEQ_EVENTO = " + seq_evento + " " +
                                "AND ID_TP_EVENTO = " + id_tp_evento + " ";
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    valret= cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return valret;
        }

        public DataSet descricao_evento_por_demanda(bool cronograma)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY 1
                cGlobal.query = "SELECT DISTINCT YEAR(DT_USER_CAD) AS ANO, SEQ_EVENTO FROM EVENTO_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Evento");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 2
                if (cronograma)
                {
                    cGlobal.query = "SELECT DISTINCT SEQ_EVENTO, ID_TP_EVENTO FROM CRONOGRAMA_TB ";
                }
                else
                {
                    cGlobal.query = "SELECT * FROM DESCRICAO_EVENTO_TB ";
                }

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "DescEvento");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region QUERY 3
                cGlobal.query = "SELECT * FROM TIPO_EVENTO_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "TpEvento");
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                #region RELACIONANDO DATASET
                dst.Relations.Clear();
                dst.Relations.Add("A", dst.Tables["Evento"].Columns["SEQ_EVENTO"], dst.Tables["DescEvento"].Columns["SEQ_EVENTO"], false);
                dst.Relations.Add("B", dst.Tables["DescEvento"].Columns["ID_TP_EVENTO"], dst.Tables["TpEvento"].Columns["ID_TP_EVENTO"], false);

                #endregion

                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_descricao_evento(int seq_evento, int id_tp_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT " +
                                "TB3.RAZAO_SOCIAL," +
                                "TB3.SIGLA_SAC," +
                                "TB3.SIGLA_FY," +
                                "TB3.CNPJ_CPF," +
                                "TB4.PRODUTO," +
                                "TB5.CLIENTE," +
                                "TB6.STATUS AS [STATUS_DEMANDA]," +
                                "TB2.FLAG," +
                                "TB1.DTDEMANDA, " +
                                "TB1.DTCOTA, " +
                                "TB1.STATUS, " +
                                "TB2.USER_CAD, " +
                                "TB2.DT_USER_CAD, " +
                                "TB2.GOV_CAD, " +
                                "TB2.DT_GOV_CAD, " +
                                "TB2.CAPACITY_CAD, " +
                                "TB2.DT_CAPACITY_CAD, " +
                                "TB2.RTO_CAD, " +
                                "TB2.DT_RTO_CAD " +
                                "FROM DESCRICAO_EVENTO_TB TB1, EVENTO_TB TB2, FUNDO_TB TB3, PRODUTO_TB TB4, CLIENTE_TB TB5, STATUS_TB TB6 " +
                                "WHERE TB1.SEQ_EVENTO = TB2.SEQ_EVENTO " +
                                "AND TB3.ID_FUNDO = TB2.ID_FUNDO " +
                                "AND TB4.ID_PRODUTO = TB2.ID_PRODUTO " +
                                "AND TB5.ID_CLIENTE = TB2.ID_CLIENTE " +
                                "AND TB6.ID_STATUS = TB2.ID_STATUS " +
                                "AND TB1.SEQ_EVENTO = " + seq_evento + " " +
                                "AND TB1.ID_TP_EVENTO = " + id_tp_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "RetDescEvento");
                    }
                }
                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public string retorna_status_do_evento(int seq_evento)
        {
            string retorno = string.Empty;
            try
            {
                #region QUERY
                cGlobal.query = "SELECT FLAG FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retorno = dr["FLAG"].ToString();
                        }
                    }
                }
                cConexao.fecha_conexao();
                #endregion
                return retorno;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool retorna_status_capacity_do_evento(int seq_evento)
        {
            bool retorno = false;
            try
            {
                #region QUERY
                cGlobal.query = "SELECT FLAG_CAPACITY FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retorno = dr["FLAG_CAPACITY"].ToString() == "true";
                            
                        }
                    }
                }
                cConexao.fecha_conexao();
                #endregion
                return retorno;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }


        public bool acha_fundo(string param)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB TB1, FUNDO_TB TB2 WHERE TB1.ID_FUNDO = TB2.ID_FUNDO AND TB2.RAZAO_SOCIAL LIKE '%" + param + "%' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool acha_cliente(string param)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB TB1, CLIENTE_TB TB2 WHERE TB1.ID_CLIENTE = TB2.ID_CLIENTE AND TB2.CLIENTE LIKE '%" + param + "%' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool acha_status(string param)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB TB1, STATUS_TB TB2 WHERE TB1.ID_STATUS = TB2.ID_STATUS AND TB2.STATUS LIKE '%" + param + "%' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool acha_produto(string param)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB TB1, PRODUTO_TB TB2 WHERE TB1.ID_PRODUTO = TB2.ID_PRODUTO AND TB2.PRODUTO LIKE '%" + param + "%' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool acha_codigo_evento(string param)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB TB1, PRODUTO_TB TB2 WHERE TB1.ID_PRODUTO = TB2.ID_PRODUTO AND TB1.SEQ_EVENTO =" + param ;
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        
    }

    #endregion

    #region MASKARA
    public class cMaskara : cTipoEvento
    {
        #region PROPERTIES
        public int seq_evento { get; set; }
        public string nome_evento { get; set; }
        public string parecer_rto { get; set; }

       
        #endregion

        bool ret_rto;

        public int retorna_id_tipo_evento(string atividade)
        {
            int retMask = 0;

            cGlobal.query = "SELECT ID_TP_EVENTO FROM TIPO_EVENTO_TB WHERE EVENTO = '" + atividade + "' ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.Text;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retMask = Convert.ToInt32(dr["ID_TP_EVENTO"].ToString());
                    }
                    cConexao.fecha_conexao();
                }
            }
            return retMask;
        }
        public List<string> retorna_nome_evento(string atividade)
        {
            List<string> retMask = new List<string>();

            cGlobal.query = "SELECT * FROM TIPO_EVENTO_TB WHERE EVENTO = '" + atividade + "' ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.Text;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retMask.Add(dr["EVENTO"].ToString());
                    }
                    cConexao.fecha_conexao();
                }
            }
            return retMask.ToList();
        }
        public string retorna_maskara_evento(string atividade, int idEvento)
        {
            string retMask = string.Empty;
            bool flgAchouMascara = false;

            int idTipoEvento = retorna_id_tipo_evento(atividade);
            if (idTipoEvento == 0)
            {
                cLog lg = new cLog();
                lg.log = string.Concat("Erro ao consultar tipo de evento: ", atividade);
                lg.form = "retorna_maskara_evento";
                lg.metodo = "retorna_maskara_evento";
                lg.dt = DateTime.Now;
                lg.usersistema = cGlobal.userlogado;
                lg.userRede = Environment.UserName;
                lg.terminal = Environment.MachineName;
                lg.tp_flag = true;
                lg.grava_log(lg);
                return "";
            }

            cGlobal.query = "SELECT * FROM TEMP_MASCARA_TB WHERE ID_EVENTO  = " + idEvento + " AND ID_TP_EVENTO = " + idTipoEvento + " ";
            
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.Text;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retMask = dr["MASCARA"].ToString();
                        flgAchouMascara = true;
                    }
                    cConexao.fecha_conexao();
                    
                }
            }
            if (flgAchouMascara) return retMask;
            else { 
                    cGlobal.query = "SELECT * FROM TIPO_EVENTO_TB WHERE EVENTO = '" + atividade + "' ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandTimeout = 120;
                        cmd.CommandType = CommandType.Text;
                        using (OleDbDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                retMask = dr["MASCARA"].ToString();
                            }
                            cConexao.fecha_conexao();
                        }
                    }
                    return retMask ;
            }
        }
        public bool retorna_RTO(string atividade)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT * FROM TIPO_EVENTO_TB WHERE EVENTO = '" + atividade + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ret_rto = Convert.ToBoolean(dr["RTO"].ToString());
                        }
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                return ret_rto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void grava_descricao(cMaskara mask)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO DESCRICAO_EVENTO_TB (SEQ_EVENTO,ID_TP_EVENTO,DESCRICAO,RTO,DTDEMANDA) " +
                                "VALUES(" + mask.seq_evento + ",'" + mask.id_tpevento + "','" + mask.maskara + "', " + mask.parecer_rto + ", '" + DateTime.Now + "')";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_temp_mascara(cMaskara mask)
        {
            int qtde = 0;
            try
            {
                #region BUSCA MASCARA DO EVENTO
                cGlobal.query = "SELECT COUNT(*) AS TOTAL FROM TEMP_MASCARA_TB WHERE ID_TP_EVENTO = " + mask.id_tpevento + " AND ID_EVENTO = " + mask.seq_evento ;
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            qtde = Convert.ToInt16(dr["TOTAL"].ToString());
                        }
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                if (qtde == 0)
                {
                    #region INSERT
                    cGlobal.query = "INSERT INTO TEMP_MASCARA_TB (ID_EVENTO,ID_TP_EVENTO,MASCARA) " +
                                    "VALUES(" + mask.seq_evento + ",'" + mask.id_tpevento + "','" + mask.maskara + "')";
                    
                    #endregion
                }
                else
                {
                    #region UPDATE
                    cGlobal.query = "UPDATE TEMP_MASCARA_TB SET  MASCARA = '" + mask.maskara + "'" +
                                    " WHERE ID_EVENTO = " + mask.seq_evento + " AND ID_TP_EVENTO = " + mask.id_tpevento;
                    
                    #endregion
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        


        public void remove_descricao(cMaskara mask)
        {
            #region QUERY
            cGlobal.query = "DELETE FROM DESCRICAO_EVENTO_TB WHERE SEQ_EVENTO = " + mask.seq_evento + " AND ID_TP_EVENTO = " + mask.id_tpevento + " ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cConexao.fecha_conexao();
            }
            #endregion
        }
        public void remove_descricao_grid(cMaskara mask)
        {
            #region QUERY
            cGlobal.query = "DELETE FROM DESCRICAO_EVENTO_TB WHERE ID_DESCRICAO_EVENTO = " + mask.id_descricao_evento + " ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cConexao.fecha_conexao();
            }
            #endregion
        }
        
        public void remove_toda_descricao(cMaskara mask)
        {
            try
            {
                #region DELETE DESCRICAO_EVENTO_TB
                cGlobal.query = "DELETE FROM DESCRICAO_EVENTO_TB WHERE SEQ_EVENTO = " + mask.seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
                #region DELETE TEMP_MASCARA_TB
                cGlobal.query = "DELETE FROM TEMP_MASCARA_TB WHERE ID_EVENTO = " + mask.seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet retorna_descricao(int id)
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM DESCRICAO_EVENTO_TB WHERE SEQ_EVENTO = " + id + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "Descricao");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region CLIENTE
    public class cCliente
    {
        public int id_cliente { get; set; }
        public string cliente { get; set; }

        public void grava_cliente(cCliente cli)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO CLIENTE_TB (CLIENTE, USERCAD, DTCAD) " +
                                "VALUES('" + cli.cliente + "',  '" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void atualiza_cadastro_cliente(cCliente cli)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE CLIENTE_TB SET CLIENTE = '" + cli.cliente + "' " +
                                "WHERE ID_CLIENTE = " + cli.id_cliente + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool exclui_cliente(cCliente cli)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE ID_CLIENTE = " + cli.id_cliente + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    #region DELETA CLIENTE
                    cGlobal.query = "DELETE FROM CLIENTE_TB WHERE ID_CLIENTE = " + cli.id_cliente + " ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet preenche_lista_cliente()
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT ID_CLIENTE,UCASE(CLIENTE) AS CLIENTE, USERCAD, DTCAD FROM CLIENTE_TB WHERE ID_CLIENTE <> 1 ORDER BY ID_CLIENTE";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "Clientes");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int retorna_id_cliente(cCliente cli)
        {
            try
            {
                #region QUERY
                int id = 0;

                cGlobal.query = "SELECT ID_CLIENTE FROM CLIENTE_TB WHERE CLIENTE = '" + cli.cliente + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = Convert.ToInt32(dr["ID_CLIENTE"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }

                return id;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region TAREFA
    public class cTarefa
    {
        #region PROPERTIES
        public int id_atividade { get; set; }
        public int id_demanda { get; set; }
        public string atividade { get; set; }
        public int esforco_plan { get; set; }
        public DateTime dt_esforco_pla { get; set; }
        public string responsavel { get; set; }
        public DateTime dt_exec_real { get; set; }
        public int esforco_real { get; set; }
        public string status { get; set; }
        public string avaliacao { get; set; }
        public string historico { get; set; }
        #endregion

        public DataSet retorna_cronograma(int seq_evento, int id_tp_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();

            try
            {
                cGlobal.query = "SELECT CRONOGRAMA_TB.* ,TIPO_EVENTO_TB.EVENTO " +
                                "FROM CRONOGRAMA_TB, TIPO_EVENTO_TB " +
                                "WHERE CRONOGRAMA_TB.ID_TP_EVENTO = TIPO_EVENTO_TB.ID_TP_EVENTO " +
                                "AND SEQ_EVENTO = " + seq_evento + " " +
                                "AND TIPO_EVENTO_TB.ID_TP_EVENTO = " + id_tp_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Cronograma");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_atividade(cTarefa ativ)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO CRONOGRAMA_TB (ID_DEMANDA,ATIVIDADE,ESFORCO_PLAN,DT_EXEC_PLAN,RESPONSAVEL,DT_EXEC_REAL,ESFORCO_REAL,STATUS,AVALIACAO,HISTORICO,USERCAD,DTCAD) " +
                                "VALUES('" + ativ.id_demanda + "','" + ativ.atividade + "'," + ativ.esforco_plan + ",'" + ativ.dt_esforco_pla + "','" + ativ.responsavel + "','" + ativ.dt_exec_real + "'," + ativ.esforco_real + ",'" + ativ.status + "','" + ativ.avaliacao + "','" + ativ.historico + "', '" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void altera_atividade(cTarefa ativ)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE CRONOGRAMA_TB SET ATIVIDADE = '" + ativ.atividade + "', " +
                                                        "ESFORCO_PLAN = " + ativ.esforco_plan + ", " +
                                                        "DT_EXEC_PLAN = '" + ativ.dt_esforco_pla + "', " +
                                                        "RESPONSAVEL = '" + ativ.responsavel + "', " +
                                                        "DT_EXEC_REAL = '" + ativ.dt_exec_real + "', " +
                                                        "ESFORCO_REAL = " + ativ.esforco_real + ", " +
                                                        "STATUS = '" + ativ.status + "', " +
                                                        "AVALIACAO = '" + ativ.avaliacao + "', " +
                                                        "HISTORICO = '" + ativ.historico + "' " +
                                "WHERE ID_ATIVIDADE = " + ativ.id_atividade + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void deleta_atividade(cTarefa ativ)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM CRONOGRAMA_TB WHERE ID_ATIVIDADE = " + ativ.id_atividade + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

    }

    #endregion

    #region CAPACITY
    public class cCapacity : cEvento
    {
        #region PROPERTIES
        public int id_capacity { get; set; }
        public DateTime dt_capacity { get; set; }
        public string resp_capacity { get; set; }
        public float minutos_capacity { get; set; }

        public string ano { get; set; }
        #endregion

        public DataSet retorna_capacity_dia(DateTime dt)
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM CAPACITY_TB WHERE DT LIKE '%" + dt.ToShortDateString() + "%' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "Capacity");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public List<int> retorna_total_horas_evento(cCapacity cp)
        {
            List<int> retqtdhoras = new List<int>();
            retqtdhoras.Clear();
            try
            {
                cGlobal.query = "SELECT SUM(ESFORCO) AS [TOTAL_HORAS] " +
                                "FROM ATIVIDADE_TB, TIPO_EVENTO_TB " +
                                "WHERE TIPO_EVENTO_TB.ID_TP_EVENTO = ATIVIDADE_TB.ID_TP_EVENTO " +
                                "AND TIPO_EVENTO_TB.ID_TP_EVENTO " +
                                "AND TIPO_EVENTO_TB.ID_TP_EVENTO = " + cp.id_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retqtdhoras.Add(Convert.ToInt32(dr["TOTAL_HORAS"].ToString()));
                        }
                    }
                }
                cConexao.fecha_conexao();

                return retqtdhoras.ToList();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

        }

        public DataSet retorna_data_uteis()
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY 
                cGlobal.query = "SELECT DISTINCT DT FROM CAPACITY_TB WHERE DT IS NOT NULL ORDER BY DT ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "DtUteis");
                    }
                }
                #endregion
                dst.Dispose();
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool verifica_capacity_ano(cCapacity cc)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM [CAPACITY_TB] WHERE DT LIKE '%" + cc.ano + "'";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int gera_capacity(cCapacity cc)
        {
            int qtdRet = 0;
            try
            {
                #region QUERY 1
                cGlobal.query = "INSERT INTO CAPACITY_TB(DT,RESPONSAVEL,MINUTOS,DISPONIVEL,COMPROMETIDO,RESERVA,USERCAD,DTCAD)" +
                                "SELECT DATAS,'PASSIVO',2620, 2620,0,0,'" + cGlobal.userlogado + "', '" + DateTime.Now + "' FROM CALENDARIO_TB WHERE DATAS LIKE '%" + cc.ano + "'";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    qtdRet = cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
                if (qtdRet < 1) return qtdRet;

                    #region QUERY 2
                cGlobal.query = "INSERT INTO CAPACITY_TB(DT,RESPONSAVEL,MINUTOS,DISPONIVEL,COMPROMETIDO,RESERVA,USERCAD,DTCAD)" +
                                "SELECT DATAS,'PROCESSAMENTO',1123,1123,0,0,'" + cGlobal.userlogado + "', '" + DateTime.Now + "' FROM CALENDARIO_TB WHERE DATAS LIKE '%" + cc.ano + "'";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    qtdRet = cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
                if (qtdRet < 1) return qtdRet;

                #region QUERY 3
                cGlobal.query = "INSERT INTO CAPACITY_TB(DT,RESPONSAVEL,MINUTOS,DISPONIVEL,COMPROMETIDO,RESERVA,USERCAD,DTCAD)" +
                                "SELECT DATAS,'SUPORTE',1872,1872,0,0,'" + cGlobal.userlogado + "', '" + DateTime.Now + "' FROM CALENDARIO_TB WHERE DATAS LIKE '%" + cc.ano + "'";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    qtdRet = cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
                if (qtdRet < 1) return qtdRet;

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return qtdRet;
        }

    }

    #endregion

    #region DEMANDA
    public class cDemanda : cTipoEvento
    {
        public int id_demanda { get; set; }
        public string atividade { get; set; }
        public int esforco { get; set; }
        public string responsavel { get; set; }
        public int sequencia { get; set; }


        public DataSet retorna_demanda(string param)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                if (string.IsNullOrEmpty(param))
                {
                    cGlobal.query = "SELECT * FROM ATIVIDADE_TB ";
                }
                else
                {
                    //cGlobal.query = "SELECT * FROM ATIVIDADE_TB WHERE ATIVIDADE LIKE '%" + param + "%' ";
                    cGlobal.query = "SELECT TB1.* FROM ATIVIDADE_TB TB1, TIPO_EVENTO_TB TB2 " +
                                    "WHERE TB2.ID_TP_EVENTO = TB1.ID_TP_EVENTO " +
                                    "AND TB2.EVENTO LIKE '%" + param + "%' "; //+
                                                                              //"OR TB1.ATIVIDADE LIKE '%" + param + "%' ";
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Demanda");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }

                if (string.IsNullOrEmpty(param))
                {
                    cGlobal.query = "SELECT ID_TP_EVENTO, EVENTO FROM TIPO_EVENTO_TB ORDER BY EVENTO ";
                }
                else
                {
                    cGlobal.query = "SELECT ID_TP_EVENTO, EVENTO FROM TIPO_EVENTO_TB WHERE EVENTO LIKE '%" + param + "%' ";
                }

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "TpEvento");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }

                dst.Relations.Add("A", dst.Tables["TpEvento"].Columns["ID_TP_EVENTO"], dst.Tables["Demanda"].Columns["ID_TP_EVENTO"], false);

                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_demanda(cDemanda dem)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO ATIVIDADE_TB (ID_TP_EVENTO,ATIVIDADE,ESFORCO,RESPONSAVEL,SEQUENCIA,USERCAD,DTCAD) " +
                                "VALUES(" + dem.id_tpevento + ",'" + dem.atividade + "'," + dem.esforco + ",'" + dem.responsavel + "'," + dem.sequencia + ",'" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void altera_demanda(cDemanda dem)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE ATIVIDADE_TB SET ID_TP_EVENTO = " + dem.id_tpevento + ", " +
                                                      "ATIVIDADE = '" + dem.atividade + "', " +
                                                      "ESFORCO = " + dem.esforco + ", " +
                                                      "RESPONSAVEL = '" + dem.responsavel + "', " +
                                                      "SEQUENCIA = " + dem.sequencia + " " +
                                "WHERE ID_ATIVIDADE = " + dem.id_demanda + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void deleta_demanda(cDemanda dem)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM ATIVIDADE_TB WHERE ID_ATIVIDADE = " + dem.id_demanda + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }


    }

    #endregion

    #region FUNDO
    public class cFundo : cEvento
    {
        #region PROPERTIES
        public int id_Fundo { get; set; }
        public int tipo_fundo { get; set; }
        public string razao_social { get; set; }
        public string SiglaSAC { get; set; }
        public string SiglaFY { get; set; }
        public string CnpjCpf { get; set; }
        #endregion

        public void grava_fundo(cFundo fd)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO FUNDO_TB (RAZAO_SOCIAL," +
                                                      "SIGLA_SAC," +
                                                      "SIGLA_FY," +
                                                      "CNPJ_CPF," +
                                                      "USERCAD, DTCAD) " +
                                "VALUES('" + fd.razao_social + "', " +
                                       "'" + fd.SiglaSAC + "', " +
                                       "'" + fd.SiglaFY + "', " +
                                       "'" + fd.CnpjCpf + "', " +
                                       "'" + cGlobal.userlogado + "', " +
                                       "'" + DateTime.Now + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void atualiza_cadastro_fundo(cFundo fd)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE FUNDO_TB SET RAZAO_SOCIAL= '" + fd.razao_social + "', " +
                                                    "SIGLA_SAC   = '" + fd.SiglaSAC + "', " +
                                                    "SIGLA_FY    = '" + fd.SiglaFY + "', " +
                                                    "CNPJ_CPF    = '" + fd.CnpjCpf + "' " +
                                "WHERE ID_FUNDO = " + fd.id_Fundo + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool exclui_fundo(cFundo fd)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE ID_FUNDO = " + fd.id_Fundo + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    #region QUERY
                    cGlobal.query = "DELETE FROM FUNDO_TB WHERE ID_FUNDO = " + fd.id_Fundo + " ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet preenche_lista_fundo()
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM FUNDO_TB WHERE ID_FUNDO <> 1 ORDER BY ID_FUNDO DESC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "Fundo");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet carrega_combo_fundo()
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM FUNDO_TB ORDER BY 1 ASC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "TipoFundo");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_relacionamento_evento_fundo(cFundo fd)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO REL_EVENTO_FUNDO_TB (SEQ_EVENTO,ID_FUNDO) " +
                                "VALUES(" + fd.id_seq_evento + ", " + fd.id_Fundo + ") ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

        }

        public DataSet find_lista_fundo(cFundo fd)
        {
            DataSet dst = new DataSet();
            dst.Clear();

            try
            {
                cGlobal.query = "SELECT * FROM FUNDO_TB " +
                                "WHERE RAZAO_SOCIAL LIKE '%" + fd.razao_social + "%' " +
                                "ORDER BY FUNDO_TB.ID_FUNDO DESC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "FundoEvento");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet find_fundo_CNPJ(cFundo fd)
        {
            DataSet dst = new DataSet();
            dst.Clear();

            try
            {
                cGlobal.query = "SELECT * FROM FUNDO_TB " +
                                "WHERE CNPJ_CPF LIKE '" + fd.CnpjCpf.Trim() + "' " +
                                "ORDER BY FUNDO_TB.ID_FUNDO DESC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "RetFundoEvento");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void exclui_relacao_evento_fundo(cFundo fd)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM REL_EVENTO_FUNDO_TB WHERE ID_FUNDO = " + fd.id_Fundo + " AND SEQ_EVENTO = " + fd.id_seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_dados_fundo(cFundo fd)
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM FUNDO_TB WHERE ID_FUNDO = " + fd.id_Fundo + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "RetFundo");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_dados_fundo_evento(cFundo fd)
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT FUNDO_TB.*, 'ORIGEM' AS FONTE  FROM EVENTO_TB,FUNDO_TB WHERE FUNDO_TB.ID_FUNDO = EVENTO_TB.ID_FUNDO_ORIGEM AND EVENTO_TB.SEQ_EVENTO = " + fd.id_seq_evento + " " +
                                "UNION ALL " +
                                "SELECT FUNDO_TB.*, 'DESTINO' AS FONTE FROM EVENTO_TB,FUNDO_TB WHERE FUNDO_TB.ID_FUNDO = EVENTO_TB.ID_FUNDO_DESTINO AND EVENTO_TB.SEQ_EVENTO = " + fd.id_seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "RetFundo");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_planilha_fundos(string nomearquivo)
        {
            try
            {
                DataSet ds = new DataSet();
                //OleDbConnection conexao = new OleDbConnection(string.Format(@"Provider = Microsoft.ACE.OLEDB.14.0; Data Source = {0}; Extended Properties ='Excel 8.0 Xml; HDR = YES';", nomearquivo));
                OleDbConnection conexao = new OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source = {0}; Extended Properties=Excel 8.0;", nomearquivo));
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Concat("SELECT * FROM [Sheet$] WHERE [Nome do Fundo/Carteira] <> '' "), conexao);

                adapter.Fill(ds, "Planilha");
                adapter.Dispose();
                ds.Dispose();
                conexao.Dispose();
                conexao.Close();
                return ds;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool verifica_fundo_existe(cFundo fd)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM FUNDO_TB WHERE RAZAO_SOCIAL = '" + fd.razao_social + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int retorna_id_fundo(cFundo fd)
        {
            try
            {
                int id = 0;
                cGlobal.query = "SELECT ID_FUNDO FROM FUNDO_TB " +
                                "WHERE RAZAO_SOCIAL = '" + fd.razao_social + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = int.Parse(dr["ID_FUNDO"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }
                return id;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region SETOR
    public class cSetor : cEvento
    {
        #region PROPERTIES
        public int id_setor { get; set; }
        public string setor { get; set; }
        #endregion

        public DataSet preenche_lista_setor()
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM SETOR_TB ORDER BY ID_SETOR DESC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "Setor");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void grava_setor(cSetor cst)
        {
            try
            {
                try
                {
                    #region QUERY
                    cGlobal.query = "INSERT INTO SETOR_TB (SETOR, USERCAD, DTCAD) " +
                                    "VALUES('" + cst.setor + "',  '" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void atualiza_cadastro_setor(cSetor cst)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE SETOR_TB SET SETOR = '" + cst.setor + "' " +
                                "WHERE ID_SETOR = " + cst.id_setor + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool exclui_setor(cSetor cst)
        {
            try
            {
                #region VERIFICA SE SETOR TEM VINCULO COM EVENTO
                cGlobal.query = "SELECT COUNT(1) FROM REL_EVENTO_SETOR_TB WHERE ID_SETOR = " + cst.id_setor + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    #region QUERY
                    cGlobal.query = "DELETE FROM SETOR_TB WHERE ID_SETOR = " + cst.id_setor + " ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public List<int> retorna_id_setor(string setor)
        {
            List<int> retSetor = new List<int>();

            cGlobal.query = "SELECT ID_SETOR FROM SETOR_TB WHERE SETOR = '" + setor + "' ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.Text;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retSetor.Add(Convert.ToInt32(dr["ID_SETOR"].ToString()));
                    }
                    cConexao.fecha_conexao();
                }
            }
            return retSetor.ToList();
        }
        public void grava_relacao_evento_setor(cSetor cst)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO REL_EVENTO_SETOR_TB (SEQ_EVENTO," +
                                                                 "ID_SETOR) " +
                                "VALUES(" + cst.id_seq_evento + ", " +
                                       "" + cst.id_setor + ")";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void remove_relacao_evento_setor(cSetor cst)
        {
            #region QUERY
            cGlobal.query = "DELETE FROM REL_EVENTO_SETOR_TB WHERE SEQ_EVENTO = " + cst.id_seq_evento + " AND ID_SETOR = " + cst.id_setor + " ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cConexao.fecha_conexao();
            }
            #endregion
        }
        public void remove_toda_relacao_evento_setor(cSetor cst)
        {
            #region QUERY
            cGlobal.query = "DELETE FROM REL_EVENTO_SETOR_TB WHERE SEQ_EVENTO = " + cst.id_seq_evento + " ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cConexao.fecha_conexao();
            }
            #endregion
        }
    }

    #endregion

    #region STATUS
    public class cStatus
    {
        #region PROPERTIES
        public int id_status { get; set; }
        public string status { get; set; }
        #endregion

        public DataSet preenche_lista_status()
        {
            DataSet dst = new DataSet();
            dst.Clear();

            try
            {
                cGlobal.query = "SELECT * FROM STATUS_TB ORDER BY ID_STATUS ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Status");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void grava_status(cStatus cs)
        {
            try
            {
                try
                {
                    #region QUERY
                    cGlobal.query = "INSERT INTO STATUS_TB (STATUS, USERCAD, DTCAD) " +
                                    "VALUES('" + cs.status + "',  '" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void atualiza_cadastro_status(cStatus cs)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE STATUS_TB SET STATUS = '" + cs.status + "' " +
                                "WHERE ID_STATUS = " + cs.id_status + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool exclui_status(cStatus cs)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE ID_STATUS = " + cs.id_status + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    #region QUERY
                    cGlobal.query = "DELETE FROM STATUS_TB WHERE ID_STATUS = " + cs.id_status + " ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region TIPO EVENTO
    public class cTipoEvento
    {
        #region PROPERTIES
        public int id_tpevento { get; set; }
        public string tpevento { get; set; }
        public string maskara { get; set; }
        public string recomendacoes { get; set; }
        public DateTime dtdemanda { get; set; }
        public DateTime dtcota { get; set; }
        public bool rto { get; set; }

        public bool flgHabilitado { get; set; }
        public int codPassivo { get; set; }
        public int codAtivo { get; set; }

        public bool flag_excecao { get; set; }
        #endregion

        public int id_descricao_evento { get; set; }

        public DataSet preenche_lista_tpeventos()
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                // busca todos os eventos pré cadastrados com codigo de tamanho padrao. 
                // Todos os registros devem ser cadastrados com tamanho padrao (N/A)

                cGlobal.query = "SELECT TIPO_EVENTO_TB.ID_TP_EVENTO, TIPO_EVENTO_TB.EVENTO, TIPO_EVENTO_TB.MASCARA, TIPO_EVENTO_TB.RECOMENDACOES, TIPO_EVENTO_TB.RTO, TIPO_EVENTO_TB.FLAG, TIPO_EVENTO_TB.USERCAD, TIPO_EVENTO_TB.DTCAD, TIPO_EVENTO_TB.FLGHABILITADO " +
                                "FROM TIPO_EVENTO_TB , ATIVIDADE_TB " +
                                "WHERE ATIVIDADE_TB.ID_TP_EVENTO = TIPO_EVENTO_TB.ID_TP_EVENTO " + // AND TIPO_EVENTO_TB.CODTAMANHO = 0 " +
                                "GROUP BY TIPO_EVENTO_TB.ID_TP_EVENTO, TIPO_EVENTO_TB.EVENTO, TIPO_EVENTO_TB.MASCARA, TIPO_EVENTO_TB.RECOMENDACOES, TIPO_EVENTO_TB.RTO, TIPO_EVENTO_TB.FLAG, TIPO_EVENTO_TB.USERCAD, TIPO_EVENTO_TB.DTCAD, TIPO_EVENTO_TB.FLGHABILITADO " +
                                "ORDER BY EVENTO ASC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "TpEventos");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public List<int> retorna_id_tp_evento(string evento)
        {
            List<int> lsID = new List<int>();
            lsID.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT ID_TP_EVENTO FROM TIPO_EVENTO_TB WHERE EVENTO = '" + evento + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lsID.Add(int.Parse(dr["ID_TP_EVENTO"].ToString()));
                        }
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                return lsID.ToList();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_tipo_evento(cTipoEvento ctp)
        {
            try
            {
                try
                {
                    #region QUERY
                    cGlobal.query = "INSERT INTO TIPO_EVENTO_TB (EVENTO, " +
                                                                "MASCARA,  " +
                                                                "RECOMENDACOES,  " +
                                                                "RTO,  " +
                                                                "FLAG,  " +
                                                                "USERCAD,  " +
                                                                "DTCAD, " +
                                                                "FLGHABILITADO) " +
                                    "VALUES('" + ctp.tpevento + "', " +
                                           "'" + ctp.maskara + "', " +
                                           "'" + ctp.recomendacoes + "', " +
                                           "" + ctp.rto + ", " +
                                           "" + ctp.flag_excecao + ", " +
                                           "'" + cGlobal.userlogado + "', " +
                                           "'" + DateTime.Now + "', " +
                                           "" + ctp.flgHabilitado + ")";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandTimeout = 120;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    cConexao.fecha_conexao();
                    #endregion
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool exclui_tpevento(cTipoEvento ctp)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM DESCRICAO_EVENTO_TB WHERE ID_TP_EVENTO = " + ctp.id_tpevento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    #region GRAVA ALTERACAO USUARIO
                    cGlobal.query = "DELETE FROM TIPO_EVENTO_TB WHERE ID_TP_EVENTO = " + ctp.id_tpevento + " ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cConexao.fecha_conexao();
                    }
                    #endregion
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void atualiza_cadastro_tpevento(cTipoEvento ctp)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE TIPO_EVENTO_TB SET EVENTO = '" + ctp.tpevento + "'," +
                                                          "MASCARA= '" + ctp.maskara + "'," +
                                                          "RECOMENDACOES = '" + ctp.recomendacoes + "'," +
                                                          "RTO = " + ctp.rto + ", " +
                                                          "FLAG = " + ctp.flag_excecao + ", " +
                                                          "flgHabilitado = " + ctp.flgHabilitado + " " +
                                "WHERE ID_TP_EVENTO = " + ctp.id_tpevento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_descricao_evento(cTipoEvento ctp)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT TIPO_EVENTO_TB.EVENTO, DESCRICAO_EVENTO_TB.* FROM DESCRICAO_EVENTO_TB, TIPO_EVENTO_TB " +
                                "WHERE TIPO_EVENTO_TB.ID_TP_EVENTO = DESCRICAO_EVENTO_TB.ID_TP_EVENTO " +
                                "AND   DESCRICAO_EVENTO_TB.ID_DESCRICAO_EVENTO = " + ctp.id_descricao_evento + " AND TIPO_EVENTO_TP.FLGHABILITADO = TRUE ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "DescEvento");
                    }
                }
                dst.Dispose();
                cConexao.fecha_conexao();
                #endregion
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void atualiza_descricao_evento(cTipoEvento ctp)
        {
            try
            {
                #region QUERY
                //cGlobal.query = "UPDATE DESCRICAO_EVENTO_TB SET DESCRICAO = '" + ctp.maskara + "'," +
                //                                               "DTDEMANDA = '" + ctp.dtdemanda + "'," +
                //                                               "DTCOTA = '" + ctp.dtcota.ToShortDateString() + "'," +
                //                                               "HRCOTA= '" + ctp.dtcota.ToShortTimeString() + "'," +
                //                                               "RTO = " + ctp.rto + " " + 
                //                "WHERE ID_DESCRICAO_EVENTO = " + ctp.id_descricao_evento + " ";
                
                cGlobal.query = "UPDATE DESCRICAO_EVENTO_TB SET DTCOTA = " + (DateTime.Compare(ctp.dtcota,DateTime.MinValue)==0?"NULL".ToString():"'" + ctp.dtcota.ToShortDateString().ToString() + "'") +
                                ", CDPASSIVO = " + ctp.codPassivo + ", CDATIVO = " + ctp.codAtivo + 
                                " WHERE ID_DESCRICAO_EVENTO = " + ctp.id_descricao_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region USUARIOS
    public class cUsuario : cSetor
    {
        #region PROPERTIES
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public bool cad_evento { get; set; }
        public bool apr_evento { get; set; }
        public bool cad_cliente { get; set; }
        public bool cronograma { get; set; }
        public bool produto { get; set; }
        public bool suporte { get; set; }
        public bool reset_pwd { get; set; }
        public DateTime dtcad { get; set; }
        public bool adm { get; set; }
        public bool inativo { get; set; }
        #endregion

        public bool valida_login(cUsuario user)
        {
            try
            {
                #region RETORNA LINHA AFETADA
                cGlobal.query = "SELECT COUNT(1) FROM USUARIO_TB WHERE LOGIN = '" + user.usuario + "' AND PWD = '" + user.senha + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline == 0)
                {
                    return false;
                }
                else
                {
                    #region RETORNA DADOS DO USUARIO
                    cGlobal.query = "SELECT LOGIN FROM USUARIO_TB WHERE LOGIN = '" + user.usuario + "' AND PWD = '" + user.senha + "' ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (OleDbDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                cGlobal.userlogado = dr["LOGIN"].ToString();
                            }
                        }
                        cConexao.fecha_conexao();
                    }
                    #endregion
                    return true;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool verifica_reset_senha(cUsuario user)
        {
            #region RETORNA LINHA AFETADA
            cGlobal.query = "SELECT COUNT(1) FROM USUARIO_TB WHERE LOGIN = '" + user.usuario + "' AND PWD = '" + user.senha + "' AND RESET_PWD = -1 ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandType = CommandType.Text;
                cGlobal.existline = (Int32)cmd.ExecuteScalar();
                cConexao.fecha_conexao();
            }
            #endregion

            if (cGlobal.existline == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void grava_acesso(cUsuario user)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO USUARIO_TB (USUARIO," +
                                                        "EMAIL," +
                                                        "LOGIN," +
                                                        "PWD," +
                                                        "CAD_EVENTO," +
                                                        "APR_EVENTO," +
                                                        "CAD_CLIENTE," +
                                                        "CRONOGRAMA," +
                                                        "PRODUTO," +
                                                        "SUPORTE," +
                                                        "DTCAD," +
                                                        "RESET_PWD," +
                                                        "ADM," +
                                                        "ATIVO)" +
                                "VALUES('" + user.usuario + "', " +
                                       "'" + user.email + "', " +
                                       "'" + user.login + "', " +
                                       "'" + user.senha + "', " +
                                       "1," +
                                       "0," +
                                       "0," +
                                       "0," +
                                       "0," +
                                       "0," +
                                       "'" + user.dtcad + "'," +
                                       "0," +
                                       "0," +
                                       "1)";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public int retorna_id_usuario(cUsuario user)
        {
            try
            {
                #region RETORNO
                int id = 0;

                cGlobal.query = "SELECT ID_USUARIO FROM USUARIO_TB WHERE LOGIN = '" + user.usuario + "' AND PWD = '" + user.senha + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = Convert.ToInt32(dr["ID_USUARIO"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }

                return id;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void grava_alteracao_senha(cUsuario user)
        {
            try
            {
                #region GRAVA ALTERACAO USUARIO
                cGlobal.query = "UPDATE USUARIO_TB SET PWD = '" + user.senha + "'," +
                                                      "RESET_PWD = 0 " +
                                "WHERE ID_USUARIO = " + user.id_usuario + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool verifica_usuario_existe(cUsuario user)
        {
            try
            {
                #region QUEEY
                cGlobal.query = "SELECT COUNT(1) FROM USUARIO_TB WHERE LOGIN = '" + user.usuario + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                    cConexao.fecha_conexao();
                }
                #endregion

                if (cGlobal.existline == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet preenche_lista_usuario()
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY 1
                cGlobal.query = "SELECT * FROM USUARIO_TB WHERE USUARIO <> 'ADMINISTRADOR' ORDER BY ID_USUARIO DESC";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Usuarios");
                    }
                    cConexao.fecha_conexao();
                }
                #endregion

                dst.Dispose();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void atualiza_cadastro_usuario(cUsuario user, bool altsenha)
        {
            try
            {
                #region QUERY
                if (!altsenha)
                {
                    cGlobal.query = "UPDATE USUARIO_TB SET USUARIO = '" + user.usuario + "'," +
                                                     "EMAIL = '" + user.email + "'," +
                                                     "LOGIN = '" + user.login + "'," +
                                                     "CAD_EVENTO = " + user.cad_evento + "," +
                                                     "APR_EVENTO = " + user.apr_evento + "," +
                                                     "CAD_CLIENTE = " + user.cad_cliente + "," +
                                                     "CRONOGRAMA = " + user.cronograma + "," +
                                                     "PRODUTO = " + user.produto + "," +
                                                     "SUPORTE = " + user.suporte + "," +
                                                     "RESET_PWD = " + user.reset_pwd + "," +
                                                     "ADM = " + user.adm + "," +
                                                     "ATIVO = " + user.inativo + "," +
                                                     "ID_SETOR = " + user.id_setor + " " +
                               "WHERE ID_USUARIO = " + user.id_usuario + " ";
                }
                else
                {
                    cGlobal.query = "UPDATE USUARIO_TB SET USUARIO = '" + user.usuario + "'," +
                                                     "EMAIL = '" + user.email + "'," +
                                                     "LOGIN = '" + user.login + "'," +
                                                     "PWD = '" + user.senha + "'," +
                                                     "CAD_EVENTO = " + user.cad_evento + "," +
                                                     "APR_EVENTO = " + user.apr_evento + "," +
                                                     "CAD_CLIENTE = " + user.cad_cliente + "," +
                                                     "CRONOGRAMA = " + user.cronograma + "," +
                                                     "PRODUTO = " + user.produto + "," +
                                                     "SUPORTE = " + user.suporte + "," +
                                                     "RESET_PWD = " + user.reset_pwd + "," +
                                                     "ADM = " + user.adm + "," +
                                                     "ATIVO = " + user.inativo + ", " +
                                                     "ID_SETOR = " + user.id_setor + " " +
                               "WHERE ID_USUARIO = " + user.id_usuario + " ";
                }

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void exclui_usuario(cUsuario user)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM USUARIO_TB WHERE ID_USUARIO = " + user.id_usuario + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public List<cPermissao> retorna_permissoes(cUsuario user)
        {
            List<cPermissao> per = new List<cPermissao>();
            per.Clear();
            try
            {
                cGlobal.query = "SELECT * FROM USUARIO_TB WHERE LOGIN = '" + user.login + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            per.Add(new cPermissao(Convert.ToBoolean(dr["CAD_EVENTO"].ToString()),
                                                   Convert.ToBoolean(dr["APR_EVENTO"].ToString()),
                                                   Convert.ToBoolean(dr["CAD_CLIENTE"].ToString()),
                                                   Convert.ToBoolean(dr["CRONOGRAMA"].ToString()),
                                                   Convert.ToBoolean(dr["PRODUTO"].ToString()),
                                                   Convert.ToBoolean(dr["SUPORTE"].ToString())
                                ));
                        }
                    }
                    cConexao.fecha_conexao();
                }
                return per.ToList();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool verifica_bloqueio_usuario()
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM BLOQUEIO_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                #endregion

                if (cGlobal.existline == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public List<string> retorna_usuario_bloqueio()
        {
            List<string> userblock = new List<string>();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT USERCAD FROM BLOQUEIO_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            userblock.Add(dr["USERCAD"].ToString());
                        }
                    }
                }
                cConexao.fecha_conexao();
                #endregion

                return userblock.ToList();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void bloqueia_usuario_capacity(cUsuario user, bool flag)
        {
            try
            {
                #region QUERY
                if (flag)
                {
                    cGlobal.query = "INSERT INTO BLOQUEIO_TB(USERCAD,DTCAD) VALUES('" + user.login + "', '" + DateTime.Now + "')";
                }
                else
                {
                    cGlobal.query = "DELETE FROM BLOQUEIO_TB ";
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool verifica_login_ativo(cUsuario user)
        {
            #region QUERY
            cGlobal.query = "SELECT COUNT(1) FROM USUARIO_TB WHERE LOGIN = '" + user.usuario + "' AND PWD = '" + user.senha + "' AND ATIVO = 0 ";
            using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
            {
                cmd.CommandType = CommandType.Text;
                cGlobal.existline = (Int32)cmd.ExecuteScalar();
                cConexao.fecha_conexao();
            }
            #endregion

            if (cGlobal.existline == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataSet retorna_usuario_bloqueado()
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                cGlobal.query = "SELECT * FROM BLOQUEIO_TB";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Bloqueio");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet retorna_permissoes_aprovacao(string usuariologado)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                cGlobal.query = "SELECT " +
                                "APR_EVENTO AS[GOVERNANCA], " +
                                "PRODUTO AS[CAPACITY], " +
                                "SUPORTE AS[SUPORTE] " +
                                "FROM[USUARIO_TB] " +
                                "WHERE LOGIN = '" + usuariologado + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "RetPermApr");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_area_usuario(int id_user, int area)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY 1
                cGlobal.query = "SELECT TB1.ID_USUARIO, TB1.ID_SETOR, TB2.SETOR FROM USUARIO_TB TB1, SETOR_TB TB2 WHERE TB2.ID_SETOR = TB1.ID_SETOR AND  TB1.ID_USUARIO = " + id_user + " AND TB1.ID_SETOR = " + area + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Area");
                    }
                    cConexao.fecha_conexao();
                }
                #endregion

                dst.Dispose();
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

    }

    #endregion

    #region LOG
    public class cLog
    {
        public string log { get; set; }
        public string form { get; set; }
        public string metodo { get; set; }
        public DateTime dt { get; set; }
        public string usersistema { get; set; }
        public string userRede { get; set; }
        public string terminal { get; set; }
        public bool tp_flag { get; set; }

        public void grava_log(cLog log)
        {
            try
            {
                cGlobal.query = "INSERT INTO LOG_TB(LOG,FORM,METODO,DT,USER_SISTEMA,USER_REDE,TERMINAL,FLAG) VALUES('" + log.log + "','" + log.form + "', '" + log.metodo + "', '" + log.dt + "','" + log.usersistema + "','" + log.userRede + "','" + log.terminal + "', " + log.tp_flag + ")";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet retorna_log(bool flag)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                if (flag)
                {
                    cGlobal.query = "SELECT * FROM LOG_TB WHERE FLAG = TRUE ORDER BY ID_LOG ASC";
                }
                else
                {
                    cGlobal.query = "SELECT * FROM LOG_TB WHERE FLAG = FALSE ORDER BY ID_LOG ASC";
                }

                #endregion

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Log");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region PERMISSAO
    public class cPermissao
    {
        public bool per_cad_evento { get; set; }
        public bool per_aprova_evento { get; set; }
        public bool per_cad_cliente { get; set; }
        public bool per_cronograma { get; set; }
        public bool per_produto { get; set; }
        public bool per_suporte { get; set; }

        public cPermissao(bool _per_cad_evento,
                          bool _per_aprova_evento,
                          bool _per_cad_cliente,
                          bool _per_cronograma,
                          bool _per_produto,
                          bool _per_suporte
                         )
        {
            per_cad_evento = _per_cad_evento;
            per_aprova_evento = _per_aprova_evento;
            per_cad_cliente = _per_cad_cliente;
            per_cronograma = _per_cronograma;
            per_produto = _per_produto;
            per_suporte = _per_suporte;
        }

        public cPermissao() { }
    }

    #endregion

    #region RELATORIO
    public class cRelatorio
    {
        public DataTable report_atividade(DateTime pDtini, DateTime pDtfim)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT " +
                                "TB1.ID_CRONOGRAMA AS[ID_CRONOGRAMA], " +
                                "TB1.DT_EXEC_PLAN AS[DATA_EXECUCAO_PLANEJADO], " +
                                "TB1.ESFORCO_PLAN AS[ESFORCO_PLANEJADO], " +
                                "TB2.EVENTO AS[EVENTO], " +
                                "TB3.CLIENTE AS[CLIENTE], " +
                                "TB5.SETOR AS[INTRAG], " +
                                "TB9.SIGLA_SAC AS[SIGLA_SAC], " +
                                "TB9.SIGLA_FY AS[SIGLA_FY], " +
                                "TB9.CNPJ_CPF AS[CNPJ_CPF], " +
                                "TB7.DTDEMANDA AS[DATA_DEMANDA], " +
                                "TB9.RAZAO_SOCIAL AS[RAZAO_SOCIAL], " +
                                "TB1.RESPONSAVEL AS[RESPONSAVEL], " +
                                "TB4.SEQ_EVENTO AS[ID_DEMANDA], " +
                                "TB1.ATIVIDADE AS[ATIVIDADE], " +
                                "TB1.AVALIACAO AS[AVALIACAO], " +
                                "TB1.STATUS AS[STATUS] " +
                                "FROM CRONOGRAMA_TB TB1, TIPO_EVENTO_TB TB2, CLIENTE_TB TB3, EVENTO_TB TB4, SETOR_TB TB5, REL_EVENTO_SETOR_TB TB6, ATIVIDADE_TB TB8, DESCRICAO_EVENTO_TB TB7, FUNDO_TB TB9 " +
                                "WHERE TB1.ID_TP_EVENTO = TB8.ID_TP_EVENTO " +
                                "AND TB8.ID_TP_EVENTO = TB2.ID_TP_EVENTO " +
                                "AND TB2.ID_TP_EVENTO = TB7.ID_TP_EVENTO " +
                                "AND TB7.SEQ_EVENTO = TB1.SEQ_EVENTO " +
                                "AND TB4.SEQ_EVENTO = TB1.SEQ_EVENTO " +
                                "AND TB4.ID_CLIENTE = TB3.ID_CLIENTE " +
                                "AND TB4.ID_FUNDO_ORIGEM = TB9.ID_FUNDO " +
                                "AND TB5.ID_SETOR = TB6.ID_SETOR " +
                                "AND TB6.SEQ_EVENTO = TB4.SEQ_EVENTO " +
                                "AND TB1.DT_EXEC_PLAN  between @dataini " + 
                                "AND @datafim " +
                                "GROUP BY " +
                                "TB1.ID_CRONOGRAMA, " +
                                "TB1.DT_EXEC_PLAN, " +
                                "TB1.ESFORCO_PLAN, " +
                                "TB2.EVENTO, " +
                                "TB3.CLIENTE, " +
                                "TB5.SETOR, " +
                                "TB9.SIGLA_SAC, " +
                                "TB9.SIGLA_FY, " +
                                "TB9.CNPJ_CPF, " +
                                "TB7.DTDEMANDA, " +
                                "TB9.RAZAO_SOCIAL, " +
                                "TB1.RESPONSAVEL, " +
                                "TB4.SEQ_EVENTO, " +
                                "TB1.ATIVIDADE, " +
                                "TB1.AVALIACAO, " +
                                "TB1.STATUS ";
                #endregion
                OleDbParameter dtIni = new OleDbParameter("@dataini", DbType.Date);
                dtIni.Value = DateTime.Parse(pDtini.ToShortDateString());

                OleDbParameter dtFim = new OleDbParameter("@datafim", DbType.Date);
                dtFim.Value = DateTime.Parse(pDtfim.ToShortDateString());

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.Parameters.AddRange(new OleDbParameter[] { dtIni, dtFim });
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    dt.Dispose();
                }
                cConexao.fecha_conexao();
                return dt;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataTable report_periodo()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT " +
                                "TB7.DTDEMANDA AS [DATA_DEMANDA], " +
                                "TB4.USER_CAD AS [REGISTRADO_POR], " +
                                "TB5.SETOR AS [SETOR], " +
                                "TB3.CLIENTE AS [CLIENTE], " +
                                "TB2.EVENTO AS [TIPO_EVENTO], " +
                                "TB10.STATUS AS [STATUS], " +
                                "TB9.SIGLA_SAC AS [SIGLA_SAC], " +
                                "TB9.SIGLA_FY AS [SIGLA_FY], " +
                                "TB9.CNPJ_CPF AS [CNPJ_CPF], " +
                                "TB9.RAZAO_SOCIAL AS [RAZAO_SOCIAL], " +
                                "TB7.DTCOTA AS [DATA_COTA], " +
                                "'' AS [COMISSAO], " +
                                "TB4.FLAG AS [TIPO], " +
                                "TB11.PRODUTO AS [PRODUTO], " +
                                "TB2.RTO AS [PARECER_RTO], " +
                                "TB4.EXTRAPAUTA, " +
                                "TB4.EXCECAO " +
                                "FROM CRONOGRAMA_TB TB1, TIPO_EVENTO_TB TB2, CLIENTE_TB TB3, EVENTO_TB TB4, SETOR_TB TB5, REL_EVENTO_SETOR_TB TB6, DESCRICAO_EVENTO_TB TB7, ATIVIDADE_TB TB8, FUNDO_TB TB9, STATUS_TB TB10, PRODUTO_TB TB11 " +
                                "WHERE TB1.ID_TP_EVENTO = TB8.ID_TP_EVENTO " +
                                "AND TB8.ID_TP_EVENTO = TB2.ID_TP_EVENTO " +
                                "AND TB2.ID_TP_EVENTO = TB7.ID_TP_EVENTO " +
                                "AND TB7.SEQ_EVENTO = TB1.SEQ_EVENTO " +
                                "AND TB4.SEQ_EVENTO = TB1.SEQ_EVENTO " +
                                "AND TB4.ID_CLIENTE = TB3.ID_CLIENTE " +
                                "AND TB4.ID_FUNDO_ORIGEM = TB9.ID_FUNDO " +
                                "AND TB4.ID_PRODUTO = TB11.ID_PRODUTO " +
                                "AND TB4.ID_STATUS = TB10.ID_STATUS " +
                                "AND TB5.ID_SETOR = TB6.ID_SETOR " +
                                "AND TB7.SEQ_EVENTO = TB6.SEQ_EVENTO " +
                                "GROUP BY " +
                                "TB7.DTDEMANDA, " +
                                "TB4.USER_CAD, " +
                                "TB5.SETOR, " +
                                "TB3.CLIENTE, " +
                                "TB2.EVENTO, " +
                                "TB10.STATUS, " +
                                "TB9.SIGLA_SAC, " +
                                "TB9.SIGLA_FY, " +
                                "TB9.CNPJ_CPF, " +
                                "TB9.RAZAO_SOCIAL, " +
                                "TB7.DTCOTA, " +
                                "TB4.FLAG, " +
                                "TB11.PRODUTO, " +
                                "TB2.RTO, " +
                                "TB4.EXTRAPAUTA, " +
                                "TB4.EXCECAO";
                #endregion
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    dt.Dispose();
                }
                cConexao.fecha_conexao();
                return dt;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

    }

    #endregion

    #region PRODUTO
    public class cProduto
    {
        public int idproduto { get; set; }
        public string produto { get; set; }

        public DataSet preenche_lista_produto()
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT * FROM PRODUTO_TB";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "Produto");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_produto(cProduto cprod)
        {
            try
            {
                try
                {
                    #region QUERY
                    cGlobal.query = "INSERT INTO PRODUTO_TB (PRODUTO, USERCAD, DTCAD) " +
                                    "VALUES('" + cprod.produto + "',  '" + cGlobal.userlogado + "', '" + DateTime.Now + "') ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandTimeout = 120;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    cConexao.fecha_conexao();
                    #endregion
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void atualiza_cadastro_produto(cProduto cprod)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE PRODUTO_TB SET PRODUTO = '" + cprod.produto + "' " +
                                "WHERE ID_PRODUTO = " + cprod.idproduto + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool exclui_produto(cProduto cprod)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE ID_PRODUTO = " + cprod.idproduto + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                #endregion

                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    #region QUERY
                    cGlobal.query = "DELETE FROM PRODUTO_TB WHERE ID_PRODUTO = " + cprod.idproduto + " ";
                    using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                    {
                        cmd.CommandTimeout = 120;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    cConexao.fecha_conexao();
                    #endregion
                    return false;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }


    }
    #endregion

    #region CRONOGRAMA
    public class previa_Cronograma
    {
        #region PROPERTIES
        public int id_cronograma { get; set; }
        public int pc_idevento { get; set; }
        public int pc_idtpevento { get; set; }
        public string pc_ativ { get; set; }
        public int pc_esfplan { get; set; }
        public DateTime pc_dtesfplan { get; set; }
        public string pc_resp { get; set; }
        public DateTime pc_dtexecreal { get; set; }
        public int pc_esfreal { get; set; }
        public string pc_status { get; set; }
        public string pc_avaliacao { get; set; }
        public string pc_historico { get; set; }
        public bool pc_cadastro_falha { get; set; }
        public bool pc_cadastro_atraso { get; set; }
        public bool pc_passivo_falha { get; set; }
        public bool pc_passivo_atraso { get; set; }
        public bool pc_relac_falha { get; set; }
        public bool pc_relac_atraso { get; set; }
        public bool pc_produto_falha { get; set; }
        public bool pc_produto_atraso { get; set; }
        public bool pc_liquid_falha { get; set; }
        public bool pc_liquid_atraso { get; set; }
        public bool pc_precif_falha { get; set; }
        public bool pc_precif_atraso { get; set; }
        public bool pc_cad_ativo_falha { get; set; }
        public bool pc_cad_ativo_atraso { get; set; }
        public bool pc_suporte_atend_falha { get; set; }
        public bool pc_suporte_atend_atraso { get; set; }
        public bool pc_suporte_proc_falha { get; set; }
        public bool pc_suporte_proc_atraso { get; set; }
        public bool pc_conciliacao_falha { get; set; }
        public bool pc_conciliacao_atraso { get; set; }
        public bool pc_cliente_falha { get; set; }
        public bool pc_cliente_atraso { get; set; }
        public bool pc_despesa_falha { get; set; }
        public bool pc_despesa_atraso { get; set; }
        public bool pc_taxas_falha { get; set; }
        public bool pc_taxas_atraso { get; set; }

        #endregion
        public previa_Cronograma() { }
        public void remove_cronograma(int seq_evento)
        {
            try
            {
                cGlobal.query = "DELETE FROM CRONOGRAMA_TB WHERE SEQ_EVENTO = " + seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void limpa_previa_cronograma()
        {
            try
            {
                cGlobal.query = "DELETE FROM PREVIA_CRONOGRAMA_TB";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool valida_feriados_cronograma(int seq_evento, int id_tp_evento)
        {
            // PENSAR NESSA ROTINA!!
            int retValue;
            try
            {
                DataSet dst = new DataSet();
                cGlobal.query = "SELECT * FROM PREVIA_CRONOGRAMA_TB WHERE SEQ_EVENTO = " + seq_evento + " " +
                                                                          " AND ID_TP_EVENTO = " + id_tp_evento;
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (retorna_feriado(Convert.ToDateTime(dr["DT_EXEC_PLAN"])))
                            {
                                cGlobal.query = "SELECT * FROM CALENDARIO_TB WHERE DATAS = @dataCalendario ";
                                int idCalendario = 0;
                                using (OleDbCommand cmd2 = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                                {
                                    using (OleDbDataReader drCalendario = cmd.ExecuteReader())
                                    {
                                        while (drCalendario.Read())
                                        {
                                            idCalendario = Convert.ToInt32(drCalendario["ID"]);
                                        }
                                    }
                                }
                                
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cConexao.fecha_conexao();
                
            }
            return true;
        }

        public int monta_previa_cronograma(int seq_evento, int id_tp_evento)
        {
            /* UPDATE: Rafael Colvara
             * Em: 18/05/2017 
             * Descrição: Considerar feriados com a tabela de feriados do sistema
             */
            int retValue = 0;
            try 
            {
                cGlobal.query = "INSERT INTO PREVIA_CRONOGRAMA_TB (" +
                                "SEQ_EVENTO," +
                                "ID_TP_EVENTO," +
                                "ATIVIDADE," +
                                "ESFORCO_PLAN," +
                                "DT_EXEC_PLAN," +
                                "RESPONSAVEL," +
                                "DTCOTA," +
                                "CALENDARIO_ID)" +
                                "SELECT " +
                                "DESCRICAO_EVENTO_TB.SEQ_EVENTO, " +
                                "DESCRICAO_EVENTO_TB.ID_TP_EVENTO, " +
                                "ATIVIDADE_TB.ATIVIDADE, " +
                                "ATIVIDADE_TB.ESFORCO, " +
                                "CALENDARIO_TB.DATAS AS[DATA ATIVIDADE]," +
                                "ATIVIDADE_TB.RESPONSAVEL," +
                                "DESCRICAO_EVENTO_TB.DTCOTA, CALENDARIO_TB.ID " +
                                "FROM ATIVIDADE_TB, DESCRICAO_EVENTO_TB, DIAS_TB, CALENDARIO_TB " +
                                "WHERE(((DIAS_TB.DATAS) = DESCRICAO_EVENTO_TB.DTCOTA) " +
                                "AND((ATIVIDADE_TB.ID_TP_EVENTO) = DESCRICAO_EVENTO_TB.ID_TP_EVENTO) " +
                                "AND ((ATIVIDADE_TB.SEQUENCIA + DIAS_TB.ID) = CALENDARIO_TB.ID) " +
                                "AND   ATIVIDADE_TB.ID_TP_EVENTO = " + id_tp_evento + ")" +
                                "AND   DESCRICAO_EVENTO_TB.SEQ_EVENTO = " + seq_evento + " " +
                                "ORDER BY DESCRICAO_EVENTO_TB.ID_TP_EVENTO, ATIVIDADE_TB.SEQUENCIA, ATIVIDADE_TB.RESPONSAVEL ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    retValue = cmd.ExecuteNonQuery();
                }

                if (retValue < 1) return retValue;
                
    
                cConexao.fecha_conexao();
                return retValue;

            }
            catch (OleDbException ex)
            {
                throw ex;
                
            }

        }
        public int grava_tabela_cronograma(int id_tp_evento, int seq_evento)
        {
            int retValue = 0;
            try
            {
                cGlobal.query = "INSERT INTO Cronograma_TB ( SEQ_EVENTO, " +
                                                            "ID_TP_EVENTO," +
                                                            "ATIVIDADE," +
                                                            "ESFORCO_PLAN," +
                                                            "DT_EXEC_PLAN," +
                                                            "RESPONSAVEL) " +
                                                            "SELECT DESCRICAO_EVENTO_TB.SEQ_EVENTO," +
                                                            "DESCRICAO_EVENTO_TB.ID_TP_EVENTO," +
                                                            "ATIVIDADE_TB.ATIVIDADE, " +
                                                            "ATIVIDADE_TB.ESFORCO, " +
                                                            "CALENDARIO_TB.DATAS AS[DATA_ATIVIDADE]," +
                                                            "ATIVIDADE_TB.RESPONSAVEL " +
                                                            "FROM ATIVIDADE_TB, DIAS_TB,DESCRICAO_EVENTO_TB,CALENDARIO_TB " +
                                                            "WHERE(((DIAS_TB.DATAS) = DESCRICAO_EVENTO_TB.DTCOTA) " +
                                                            "AND((ATIVIDADE_TB.ID_TP_EVENTO) = DESCRICAO_EVENTO_TB.ID_TP_EVENTO) " +
                                                            "AND((ATIVIDADE_TB.SEQUENCIA + DIAS_TB.ID) = CALENDARIO_TB.ID) " +
                                                            "AND     DESCRICAO_EVENTO_TB.ID_TP_EVENTO = " + id_tp_evento + " " +
                                                            "AND     DESCRICAO_EVENTO_TB.SEQ_EVENTO = " + seq_evento + ") " +
                                                            "ORDER BY DESCRICAO_EVENTO_TB.ID_TP_EVENTO, ATIVIDADE_TB.SEQUENCIA, ATIVIDADE_TB.RESPONSAVEL ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    retValue = cmd.ExecuteNonQuery();

                    cLog lg = new cLog();
                    lg.form = "cEvento";
                    lg.metodo = "grava_tabela_cronograma";
                    lg.dt = DateTime.Now;
                    lg.usersistema = cGlobal.userlogado;
                    lg.userRede = Environment.UserName;
                    lg.terminal = Environment.MachineName;
                    lg.tp_flag = false;

                    if (retValue >0)
                    {
                        #region LOG ERRO
                        lg.log = "Cronograma gerado para ID_TIPO_EVENTO = " + id_tp_evento + " e SEQ_EVENTO = " + seq_evento;
                        #endregion
                    }
                    else
                    {
                        lg.log = "*** PROBLEMAS AO GERAR CRONOGRAMA  { ID_TIPO_EVENTO = " + id_tp_evento + " e SEQ_EVENTO = " + seq_evento + " }";
                    }
                    lg.grava_log(lg);
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                retValue = -1;
                throw ex;
            }

            return retValue;
        }

      
        public void atualiza_minutos(DateTime dt, int valor, int valor_compr, int valor_reserva, string resp)
        {
            try
            {
                cGlobal.query = "UPDATE CAPACITY_TB SET DISPONIVEL = DISPONIVEL - " + valor + ", " +
                                "COMPROMETIDO = " + valor_compr + ", " +
                                "RESERVA = " + valor_reserva + " " +
                                "WHERE DT LIKE '" + dt.ToShortDateString() + "' " +
                                "AND RESPONSAVEL = '" + resp + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet retorna_dados_tabela_capacity(DateTime dt, string resp)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT DT,RESPONSAVEL,MINUTOS,DISPONIVEL,COMPROMETIDO,RESERVA " +
                                "FROM CAPACITY_TB " +
                                "WHERE DT LIKE '" + dt.ToShortDateString() + "' " +
                                "AND RESPONSAVEL = '" + resp + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "InfoCapacity");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public string retorna_nome_do_evento(int id_tp_evento)
        {
            string n_evento = string.Empty;
            try
            {
                cGlobal.query = "SELECT EVENTO FROM TIPO_EVENTO_TB WHERE ID_TP_EVENTO = " + id_tp_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            n_evento = dr["EVENTO"].ToString();
                        }
                    }
                }
                cConexao.fecha_conexao();

                return n_evento;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public string retorna_dt_minima(int seq_evento, int id_tp_evento)
        {
            string dtmin = string.Empty;
            try
            {
                cGlobal.query = "Insert into log_tb (log, form, metodo, dt, user_sistema, user_rede, terminal, flag) values (" +
                    "'Entrou na rotina e vai consultar o registro','CAPACITY','retorna_dt_minima',  '" + DateTime.Now.ToShortDateString().ToString() + "','RAFAEL','RAFAEL','computador', false)";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                
                cGlobal.query = "SELECT MIN(DT_EXEC_PLAN) AS [DT] FROM PREVIA_CRONOGRAMA_TB WHERE SEQ_EVENTO = " + seq_evento + " AND ID_TP_EVENTO = " + id_tp_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (!string.IsNullOrEmpty(dr["DT"].ToString()))
                            {
                                dtmin = dr["DT"].ToString();
                            }
                        }
                    }
                }
                cConexao.fecha_conexao();

                return dtmin;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void grava_mensagem_capacity(int seq_evento, int id_tp_evento, string status, string desc)
        {
            try
            {
                cGlobal.query = "INSERT INTO  MSG_CAP_TB(ID_SEQ," +
                                                        "ID_EVENTO," +
                                                        "STATUS," +
                                                        "DESCRICAO) " +
                                "VALUES(" + seq_evento + ", " +
                                       "" + id_tp_evento + ", " +
                                      "'" + status + "', " +
                                      "'" + desc + "')";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void grava_mensagem_email(int seq_evento, int id_tp_evento, string mensagem)
        {
            try
            {
                cGlobal.query = "INSERT INTO MSG_EMAIL_TB(ID_EVENTO," +
                                                        "ID_TIPO_EVENTO," +
                                                        "MENSAGEM) " +
                                "VALUES(" + seq_evento + ", " +
                                       "" + id_tp_evento + ", " +
                                      "'" + mensagem + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet retorna_mensagem_email(int seq_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT * " +
                                "FROM MSG_EMAIL_TB " +
                                "WHERE ID_EVENTO = " + seq_evento + " ";
                                
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "MsgEmail");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public int exclui_mensagem_email(int idEvento, int idTipoEvento)
        {
            int valRet = 0;
            try
            {
                cGlobal.query = "DELETE FROM MSG_EMAIL_TB " +
                                "WHERE ID_EVENTO  = " + idEvento + " " +
                                "AND ID_TIPO_EVENTO = " + idTipoEvento+ " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    valRet = cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return valRet;
        }
        public DataSet retorna_status(int seq_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT * " +
                                "FROM MSG_CAP_TB " +
                                "WHERE ID_SEQ = " + seq_evento + " " +
                                "AND STATUS <> 'Cronograma Gerado' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "MontMsg");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet monta_msg_outlook(int seq_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT * FROM MSG_CAP_TB WHERE ID_SEQ = " + seq_evento + " ORDER BY ID ASC ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "MontMsg");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet retorna_info_demanda(int seq_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT " +
                                "EVENTO_TB.SEQ_EVENTO, " +
                                "STATUS_TB.STATUS, " +
                                "FUNDO_TB.SIGLA_SAC, " +
                                "FUNDO_TB.CNPJ_CPF " +
                                "FROM EVENTO_TB, FUNDO_TB, STATUS_TB " +
                                "WHERE EVENTO_TB.ID_FUNDO_ORIGEM = FUNDO_TB.ID_FUNDO " +
                                "AND EVENTO_TB.ID_STATUS = STATUS_TB.ID_STATUS " +
                                "AND EVENTO_TB.SEQ_EVENTO = " + seq_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "RetInfDem");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DateTime retorna_proxima_data(DateTime dt, int preciso, string resp)
        {
            DateTime dtnext;
            cGlobal.guarda_dt = dt;
            cGlobal.min_preciso = preciso;
            cGlobal.guarda_resp = resp;
            try
            {
                cGlobal.query = "SELECT DATAS FROM DIAS_TB WHERE DATAS LIKE '" + dt.ToShortDateString() + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.HasRows)
                        {                
                            dtnext = dt.AddDays(1);
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                if (!retorna_feriado(Convert.ToDateTime(dr["DATAS"])))
                                    dtnext = Convert.ToDateTime(dr["DATAS"].ToString());
                                else
                                    retorna_proxima_data(dt.AddDays(1), preciso, resp);
                                        
                            }
                        }
                    }
                }
                cConexao.fecha_conexao();

                if (!verifica_capacity_data_proposta(cGlobal.guarda_dt, preciso, resp))
                {
                    retorna_proxima_data(cGlobal.guarda_dt.AddDays(1), cGlobal.min_preciso, cGlobal.guarda_resp);
                }

                return dtnext = Convert.ToDateTime(cGlobal.guarda_dt);
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool retorna_feriado(DateTime dtFeriado)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT 0 " +
                                "FROM FERIADOS_TB " +
                                "WHERE DATA_FERIADO LIKE '" + dtFeriado.ToShortDateString() + "' ";

                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    return dr.HasRows;
                        
                }

                
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                cConexao.fecha_conexao();
            }
        }
        public bool verifica_capacity_data_proposta(DateTime dt, int preciso, string resp)
        {
            try
            {
                cGlobal.query = "SELECT * FROM CAPACITY_TB WHERE DT LIKE '" + dt.ToShortDateString() + "' AND RESPONSAVEL = '" + resp + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cGlobal.min_disponivel = int.Parse(dr["DISPONIVEL"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }

                if (cGlobal.min_disponivel >= preciso)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataSet retorna_data_responsavel_esforco(int seq_evento, int id_tp_evento)
        {
            DataSet dst = new DataSet();
            dst.Clear();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT DT_EXEC_PLAN, RESPONSAVEL,SUM(ESFORCO_PLAN) AS ESFORCO_PLAN, ATIVIDADE, DTCOTA, SEQ_EVENTO, ID_TP_EVENTO " +
                                "FROM PREVIA_CRONOGRAMA_TB " +
                                "WHERE SEQ_EVENTO = " + seq_evento + " " +
                                "AND ID_TP_EVENTO = " + id_tp_evento + " " +
                                "GROUP BY DT_EXEC_PLAN, RESPONSAVEL, ATIVIDADE, DTCOTA, SEQ_EVENTO, ID_TP_EVENTO ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dst, "RetDtRespEsf");
                    }
                    dst.Dispose();
                }
                cConexao.fecha_conexao();
                return dst;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public List<Minutos_Disponivel> retorna_minutos_disponiveis_capacity(DateTime dt, string resp)
        {
            List<Minutos_Disponivel> mindisp = new List<Minutos_Disponivel>();
            try
            {
                #region QUERY
                cGlobal.query = "SELECT MINUTOS,DISPONIVEL,COMPROMETIDO FROM CAPACITY_TB " +
                                "WHERE DT LIKE '" + dt.ToShortDateString() + "' " +
                                "AND RESPONSAVEL = '" + resp + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            mindisp.Add(new Minutos_Disponivel(int.Parse(dr["MINUTOS"].ToString()),
                                                               int.Parse(dr["DISPONIVEL"].ToString()),
                                                               int.Parse(dr["COMPROMETIDO"].ToString())
                                                               )
                                       );
                        }
                    }
                }
                cConexao.fecha_conexao();

                return mindisp.ToList();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void limpa_mensagem()
        {
            try
            {
                cGlobal.query = "DELETE FROM MSG_CAP_TB ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public bool verifica_reserva_capacity(int seq_evento)
        {
            try
            {
                #region QUERY
                cGlobal.query = "SELECT COUNT(1) FROM EVENTO_TB WHERE SEQ_EVENTO = " + seq_evento + " AND FLAG_CAPACITY = True  ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cGlobal.existline = (Int32)cmd.ExecuteScalar();
                }
                cConexao.fecha_conexao();
                if (cGlobal.existline > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public DataTable retorna_cronograma(int seq_evento, int id_tp_evento)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                cGlobal.query = "SELECT " +
                                "ATIVIDADE, " +
                                "ESFORCO_PLAN, " +
                                "DT_EXEC_PLAN, " +
                                "RESPONSAVEL " +
                                "FROM CRONOGRAMA_TB " +
                                "WHERE SEQ_EVENTO = " + seq_evento + " " +
                                "AND ID_TP_EVENTO = " + id_tp_evento + " ";
                using (OleDbDataAdapter da = new OleDbDataAdapter(cGlobal.query, cConexao.abre_conexao()))
                {
                    da.Fill(dt);
                }
                cConexao.fecha_conexao();
                dt.Dispose();
                return dt;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void cancela_minutos_reservados(int min_esf, DateTime dt_exec, string area_resp, bool flag_reserva)
        {
            try
            {
                #region QUERY
                if (flag_reserva)
                {
                    cGlobal.query = "UPDATE CAPACITY_TB SET COMPROMETIDO = (COMPROMETIDO - " + min_esf + ") , " +
                                    "RESERVA = (RESERVA - " + min_esf + "), " +
                                    "DISPONIVEL = (DISPONIVEL + " + min_esf + ")  " +
                                    "WHERE DT LIKE '" + dt_exec.ToShortDateString() + "' " +
                                    "AND RESPONSAVEL = '" + area_resp + "' ";
                }
                else
                {
                    cGlobal.query = "UPDATE CAPACITY_TB SET COMPROMETIDO = (COMPROMETIDO - " + min_esf + ") , " +
                                    "DISPONIVEL = (DISPONIVEL + " + min_esf + ")  " +
                                    "WHERE DT LIKE '" + dt_exec.ToShortDateString() + "' " +
                                    "AND RESPONSAVEL = '" + area_resp + "' ";
                }
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void atualiza_status_cronograma(int seq_evento, int id_tp_evento)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE CRONOGRAMA_TB SET STATUS = 'Cancelado' " +
                                    "WHERE SEQ_EVENTO = " + seq_evento + " " +
                                    "AND ID_TP_EVENTO = " + id_tp_evento + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public void atualiza_cronograma(previa_Cronograma pc)
        {
            try
            {
                cGlobal.query = "UPDATE Cronograma_TB SET STATUS = '" + pc.pc_status + "', " +
                                                         "AVALIACAO = '" + pc.pc_avaliacao + "', " +
                                                         "HISTORICO = '" + pc.pc_historico + "', " +
                                                         "CADASTRO_FALHA = " + pc.pc_cadastro_falha + "," +
                                                         "CADASTRO_ATRASO = " + pc.pc_cadastro_atraso + "," +
                                                         "PASSIVO_FALHA = " + pc.pc_passivo_falha + "," +
                                                         "PASSIVO_ATRASO = " + pc.pc_passivo_atraso + "," +
                                                         "RELAC_FALHA = " + pc.pc_relac_falha + "," +
                                                         "RELAC_ATRASO = " + pc.pc_relac_atraso + "," +
                                                         "PRODUTO_FALHA = " + pc.pc_produto_falha + "," +
                                                         "PRODUTO_ATRASO = " + pc.pc_produto_atraso + "," +
                                                         "LIQUID_FALHA = " + pc.pc_liquid_falha + "," +
                                                         "LIQUID_ATRASO = " + pc.pc_liquid_atraso + "," +
                                                         "PRECIF_FALHA = " + pc.pc_precif_falha + "," +
                                                         "PRECIF_ATRASO = " + pc.pc_precif_atraso + "," +
                                                         "CAD_ATIVO_FALHA = " + pc.pc_cad_ativo_falha + "," +
                                                         "CAD_ATIVO_ATRASO = " + pc.pc_cad_ativo_atraso + "," +
                                                         "SUPORTE_ATEND_FALHA = " + pc.pc_suporte_atend_falha + "," +
                                                         "SUPORTE_ATEND_ATRASO = " + pc.pc_suporte_atend_atraso + "," +
                                                         "SUPORTE_PROC_FALHA = " + pc.pc_suporte_proc_falha + "," +
                                                         "SUPORTE_PROC_ATRASO = " + pc.pc_suporte_proc_atraso + "," +
                                                         "CONCILIACAO_FALHA = " + pc.pc_conciliacao_falha + "," +
                                                         "CONCILIACAO_ATRASO = " + pc.pc_conciliacao_atraso + "," +
                                                         "CLIENTE_FALHA = " + pc.pc_cliente_falha + "," +
                                                         "CLIENTE_ATRASO = " + pc.pc_cliente_atraso + "," +
                                                         "DESPESA_FALHA = " + pc.pc_despesa_falha + "," +
                                                         "DESPESA_ATRASO = " + pc.pc_despesa_atraso + "," +
                                                         "TAXAS_FALHA = " + pc.pc_taxas_falha + "," +
                                                         "TAXAS_ATRASO = " + pc.pc_taxas_atraso + " " +
                                    "WHERE ID_CRONOGRAMA = " + id_cronograma + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                cConexao.fecha_conexao();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }

    #endregion

    #region STATUS EVENTO
    public class status_evento
    {
        #region PROPERTIES
        public int iddem { get; set; }
        public int ideven { get; set; }
        public string neven { get; set; }
        public DateTime dteven { get; set; }
        public bool flag { get; set; }
        #endregion

        public status_evento(int _iddemanda, int _idevento, string _evento, DateTime _dtevento, bool _flag)
        {
            iddem = _iddemanda;
            ideven = _idevento;
            neven = _evento;
            dteven = _dtevento;
            flag = _flag;
        }
        public status_evento() { }
    }

    #endregion

    #region CONSTRUTOR
    public class Minutos_Disponivel
    {
        public int min { get; set; }
        public int disp { get; set; }

        public int compr { get; set; }

        public Minutos_Disponivel(int _min, int _disp, int _compr)
        {
            min = _min;
            disp = _disp;
            compr = _compr;
        }

        public Minutos_Disponivel() { }
    }

    #endregion

    #region RTO
    public class cRTO
    {
        public int idrto { get; set; }
        public DateTime dtcomissao { get; set; }
        public DateTime dtcorte { get; set; }
        public int numero { get; set; }

        public void grava_RTO(cRTO cr)
        {
            try
            {
                #region QUERY
                cGlobal.query = "INSERT INTO RTO_TB (DTCOMISSAO, DTCORTE,NUMERO) " +
                                "VALUES('" + cr.dtcomissao.ToShortDateString() + "',  '" + cr.dtcorte.ToShortDateString() + "', '" + cr.numero + "') ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public void atualiza_cadastro_RTO(cRTO cr)
        {
            try
            {
                #region QUERY
                cGlobal.query = "UPDATE RTO_TB SET DTCOMISSAO = '" + cr.dtcomissao.ToShortDateString() + "'," +
                                                  "DTCORTE = '" + cr.dtcorte.ToShortDateString() + "'," +
                                                  "NUMERO = '" + cr.numero + "' " +
                                "WHERE ID_RTO = " + cr.idrto + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public bool exclui_RTO(cRTO cr)
        {
            try
            {
                #region QUERY
                cGlobal.query = "DELETE FROM RTO_TB WHERE ID_RTO = " + cr.idrto + " ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cConexao.fecha_conexao();
                }
                #endregion
                return false;

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public DataSet preenche_lista_RTO()
        {
            DataSet dst = new DataSet();

            try
            {
                cGlobal.query = "SELECT * FROM RTO_TB ORDER BY YEAR(DTCOMISSAO), MONTH(DTCOMISSAO), DAY(DTCOMISSAO)";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        dst.Clear();
                        da.Fill(dst, "RTO");
                    }
                    dst.Dispose();
                    cConexao.fecha_conexao();
                }
                return dst;
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        public int retorna_id_RTO(cRTO cr)
        {
            try
            {
                #region QUERY
                int id = 0;

                cGlobal.query = "SELECT ID_RTO FROM RTO_TB WHERE DTCOMISSAO = '" + cr.dtcomissao.ToShortDateString() + "' AND DTCORTE = '" + cr.dtcorte.ToShortDateString() + "' AND NUMERO = '" + cr.numero + "' ";
                using (OleDbCommand cmd = new OleDbCommand(cmdText: cGlobal.query, connection: cConexao.abre_conexao()))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = Convert.ToInt32(dr["ID_RTO"].ToString());
                        }
                    }
                    cConexao.fecha_conexao();
                }

                return id;
                #endregion
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

       
    }
    #endregion

}



