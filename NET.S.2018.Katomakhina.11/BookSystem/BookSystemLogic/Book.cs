using System;

namespace BookSystemLogic
{
    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        #region private fields

        private string ISBN;
        private string author;
        private string title;
        private int year;
        private string publishingHouse;
        private decimal price;

        #endregion

        #region ctors

        public Book() { }

        public Book(string ISBN, string author, string title, int year, string publishingHouse, decimal price)
        {
            this.ISBN = ISBN;
            this.author = author;
            this.title = title;
            this.year = year;
            this.publishingHouse = publishingHouse;
            this.price = price;
        }

        #endregion

        #region properties

        public string ISBNProperty
        {
            get => ISBN;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(ISBN));
                }
                ISBN = value;
            }
        }

        public string AuthorProperty
        {
            get => author;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(author));
                }
                author = value;
            }
        }

        public string TitleProperty
        {
            get => title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(title));
                }
                title = value;
            }
        }

        public int YearProperty
        {
            get => year;
            private set
            {
                if (value <= 0) 
                {
                    throw new ArgumentException(nameof(year));
                }

                if (DateTime.Now.Year <= value)
                {
                    throw new ArgumentException(nameof(year));
                }

                year = value;
            }
        }

        public string PublishHouseProperty
        {
            get => publishingHouse;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(publishingHouse));
                }
                publishingHouse = value;
            }
        }

        public decimal PriceProperty
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(year));
                }

                price = value;
            }
        }

        #endregion

        #region override methods

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            Book other = (Book)obj;
            if (ISBN != other.ISBN)
            {
                return false;
            }
            if (author != other.author)
            {
                return false;
            }
            if (title != other.title)
            {
                return false;
            }
            if (year != other.year)
            {
                return false;
            }
            if (publishingHouse != other.publishingHouse)
            {
                return false;
            }
            if (price != other.price)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ISBN.GetHashCode();
            result = prime * result + author.GetHashCode();
            result = prime * result + title.GetHashCode();
            result = prime * result + year;
            result = prime * result + publishingHouse.GetHashCode();
            result = prime * result + (int)price;
            return result;
        }

        public override string ToString()
        {
            string information = "ISBN - {0}, author - {1}, title - {2}, year - {3}, pulishing house - {4}, price - {5},";
            return string.Format(information, ISBN, author, title, year, publishingHouse, price);
        }

        #endregion

        #region interfaces methods

        public int CompareTo(Book other) =>
            ReferenceEquals(other, null) ? 1 :
            string.Compare(this.author, other.author, StringComparison.CurrentCulture);

        public int CompareTo(object obj) =>
            ReferenceEquals(obj, null) ? 1 : 
            obj.GetType() != this.GetType() ? 1 : this.CompareTo((Book)obj);   

        public bool Equals(Book other) //???????????
        {
            if (ReferenceEquals(other, this))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return other.ISBN == ISBN;
        }

        #endregion

    }
}
