namespace Main
{
    internal class Product
    {
        private int _id = 0;
        private string _name = "0";
        private int _price = 0;
        private bool _availability = false;
        private string _category = "0";

        public Product()
        {
            _id = 0;
            _name = "Хлеб";
            _price = 59;
            _availability = true;
            _category = "Выпечка";
        }
        public Product(int id, string name, int price, bool availability, string category)
        {
            this._id = id;
            this._name = name;
            this._price = price;
            this._availability = availability;
            this._category = category;
        }
        public Product(Product i)
        {
            this._id = i._id;
            this._name = i._name;
            this._price = i._price;
            this._availability = i._availability;
            this._category = i._category;
        }
        public int ID
        { 
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public bool Availability
        {
            get
            {
                return _availability;
            }
            set
            {
                _availability = value;
            }
        }
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        public override string ToString()
        {
            return $"({ID};{Name};{Price};{Availability};{Category})";
        }
    }
}
