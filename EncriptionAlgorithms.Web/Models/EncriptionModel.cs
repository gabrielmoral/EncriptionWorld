using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EncriptionAlgorithms.Web.Models
{
    public class EncriptionModel
    {
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [DataType(DataType.MultilineText)]
        [ReadOnly(true)]
        public string ResultText { get; set; }
    }
}