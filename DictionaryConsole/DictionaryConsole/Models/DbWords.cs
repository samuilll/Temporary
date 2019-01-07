namespace DictionaryConsole
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbWords : DbContext
    {
        public DbWords()
            : base("name=DbWords")
        {
        }

        public virtual IDbSet<Word> Words { get; set; }

        public static DbWords Create()
        {
            return new DbWords();
        }
    }
}