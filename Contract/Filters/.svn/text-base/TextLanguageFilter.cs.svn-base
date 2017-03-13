using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class TextLanguageFilter : _TextLanguageFilter
    {

        #region Private
        private string _TranslateText;

        #endregion
        #region Properties
        public int? IdTextLanguage { get; set; }
        public int? IdTextLanguage_To { get; set; }
        public int? IdText { get; set; }
        public int? IdLanguage { get; set; }
        public string TranslateText
        {
            get
            {
                if (_TranslateText == null) _TranslateText = string.Empty;
                return _TranslateText;
            }
            set { _TranslateText = value; }
        }
        public bool? IsAutomaticLoad { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartDate_To { get; set; }
        public bool? Checked { get; set; }
        public bool? CheckedDateIsNull { get; set; }public DateTime? CheckedDate { get; set; }
        public DateTime? CheckedDate_To { get; set; }
        public bool? IdUsuarioCheckedIsNull { get; set; }public int? IdUsuarioChecked { get; set; }

        /// <summary>
        /// Solo para visualizacion NO PARA FILTRO
        /// </summary>
        public string UsuarioChecked_NombreCompleto { get; set; }
        /// <summary>
        /// Solo para visualizacion NO PARA FILTRO
        /// </summary>
        public string Text_Code { get; set; }
        #endregion
    }
}
