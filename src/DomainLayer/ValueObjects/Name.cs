namespace DomainLayer.ValueObjects
{
    public record Name
    {
        public string Value { get; }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A név nem lehet üres.",nameof(value));
            
            if (value.Length < 2 || value.Length>30)
                throw new ArgumentException("A név hossza minimum 2, maximum 30 karakter lehet.", nameof(value));
            
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("A névnek nagy kezdőbetűvel kell kezdődnie.", nameof(value));
            
            // Az utolsó karakter nem lehet szóköz vagy kötőjel            
            if (value[value.Length - 1] == ' ' || value[value.Length - 1] == '-')
                throw new ArgumentException("A név utolsó karaktere nem lehet szóköz vagy kötőjel.", nameof(value));
            
            // Kötőjel vagy szóköz az elején
            if ((value[0] == ' ' || value[0] == '-'))
                throw new ArgumentException("A név elején nem lehet szóköz vagy kötőjel.", nameof(value));

            for (int i = 1; i < value.Length; i++)
            {
                char currentChar = value[i];
                char previousChar = value[i - 1];

                if (!(char.IsLetter(currentChar) || currentChar==' ' || currentChar=='-'))
                    throw new ArgumentException("A név csak betűket, szóközt és  kötöjelet tartalmazhat.", nameof(value));

                // Szóköz és kötőjel után nagybetű kell legyen
                if ((previousChar == ' ' || previousChar == '-') && char.IsUpper(currentChar))
                    throw new ArgumentException("A névben nem lehet nagybetű után szóköz vagy kötőjel.", nameof(value));
                // Két szóköz vagy két kötőjel egymás után
                if ((currentChar== ' ' || currentChar == '-') && (previousChar == ' ' || previousChar == '-'))
                    throw new ArgumentException("A névben nem lehet egymás után két szóköz vagy két kötőjel.", nameof(value));
                /*
                //  Szóköz vagy kötőjel után kisbetű
                if ((currentChar == ' ' || currentChar == '-') && i+1<value.Length && !char.IsUpper(value[i+1]))
                    throw new ArgumentException("A névben nem lehet szóköz vagy kötőjel után kisbetű.", nameof(value));
                */
            }
            Value = value;
        }

        public override string ToString() => Value;
    }
}
