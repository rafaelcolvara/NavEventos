using System;

namespace NavEventos.Class
{
    public static class cGlobal
    {
        #region VARIAVEIS GLOBAL
        public static string query;
        public static int existline;
        public static string userlogado;
        public static int iduserlogado;
        public static bool editando;
        public static bool pesquisa;
        public static string reg_pesquisa;
        public static int id_fundo_pesquisa;
        public static int pesquisando;
        public static int id_desc_evento;
        public static string maskara;
        public static bool acao;
        public static bool novo;
        public static bool alterando;
        public static string infotxt;
        public static readonly object bloqueadorThread = new object();

        #endregion

        #region GERAÇÃO DE CAPACITY
        public static string capacity;
        public static string capacity_resultado;
        public static string msg_monta;
        public static int min_disponivel;
        public static DateTime guarda_dt;
        public static int min_preciso;
        public static string guarda_resp;
        public static string user_bloq;
        public static DateTime dt_blog;
        public static int id_tp_evento;
        #endregion

        #region SIMULA INPUTBOX VB.NET
        public static string InputBox(string prompt, string title, string defaultValue)
        {
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            if (s == string.Empty)
                return "";
            else
                return s;
        }

        #endregion

        #region CALCULA E RETORNA O TAMANHO DO ARQUIVO
        public static string TamanhoAmigavel(long bytes)
        {
            if (bytes < 0) throw new ArgumentException("bytes");

            double humano;
            string sufixo;

            if (bytes >= 1152921504606846976L) // Exabyte (1024^6)
            {
                humano = bytes >> 50;
                sufixo = "EB";
            }
            else if (bytes >= 1125899906842624L) // Petabyte (1024^5)
            {
                humano = bytes >> 40;
                sufixo = "PB";
            }
            else if (bytes >= 1099511627776L) // Terabyte (1024^4)
            {
                humano = bytes >> 30;
                sufixo = "TB";
            }
            else if (bytes >= 1073741824) // Gigabyte (1024^3)
            {
                humano = bytes >> 20;
                sufixo = "GB";
            }
            else if (bytes >= 1048576) // Megabyte (1024^2)
            {
                humano = bytes >> 10;
                sufixo = "MB";
            }
            else if (bytes >= 1024) // Kilobyte (1024^1)
            {
                humano = bytes;
                sufixo = "KB";
            }
            else return bytes.ToString("0 B"); // Byte

            humano /= 1024;
            return humano.ToString("0.## ") + sufixo;
        }
        #endregion

    }
}
