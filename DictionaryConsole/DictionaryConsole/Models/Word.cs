using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryConsole
{
    public class Word
    {

        [Key] public int Id { get; set; }

        public string Text { get; set; }

        public string Meaning { get; set; }

        public string Example { get; set; }

        public string Synonyms { get; set; }

        public Word(string text, string meaning, string example)
        {
            this.Text = text;
            this.Meaning = meaning;
            this.Example = example;
        }

        public Word()
        {
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("Word:\t");
            builder.AppendLine(this.Text.ToUpper());
            builder.Append("Meaning:\t");
            builder.AppendLine(this.Meaning);

            if (!string.IsNullOrEmpty(this.Example))
            {
                builder.Append("Example:\t");
                builder.AppendLine(this.Example);
            }

            if (!string.IsNullOrEmpty(this.Synonyms))
            {
                builder.Append("Synonyms:\t");
                builder.AppendLine(this.Synonyms);
            }

            return builder.ToString();
        }
    }
}
