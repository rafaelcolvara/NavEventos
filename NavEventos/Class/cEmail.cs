using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.OleDb;
using System.Data;

namespace NavEventos.Class
{
    class cEmail
    {
        private Outlook.Application outlookApp;
        public cEmail()
        {
            outlookApp = new Outlook.Application();
        }

        public void Monta(int pIdEvento, string pAssunto)
        {
            lock (cGlobal.bloqueadorThread)
            {
                int idTipoEvento = 0;
                previa_Cronograma pc = new previa_Cronograma();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;

                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;

                using (DataSet dsmsg = pc.retorna_mensagem_email(pIdEvento))
                {
                    oMailItem.Subject = dsmsg.Tables["MsgEmail"].Rows[0]["Mensagem"].ToString();
                    idTipoEvento = Convert.ToInt32(dsmsg.Tables["MsgEmail"].Rows[0]["ID_TIPO_EVENTO"].ToString());
                }

                #region MONTA CORPO DO E-MAIL
                pAssunto += oMailItem.Subject;
                oMailItem.Body = pAssunto;

                #endregion

                oMailItem.Display(true);

                if (pc.exclui_mensagem_email(pIdEvento, idTipoEvento) < 1)
                {
                    throw new Exception("Não foi possivel atualizar mensagem. Atenção no formato do email");

                }
            }
        }
    }
}
