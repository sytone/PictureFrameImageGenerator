/// Taken from: http://www.codeproject.com/Articles/27242/ExifTagCollection-An-EXIF-metadata-extraction-libr
/// Licensed under The Code Project Open License (CPOL)
/// Modifications have been made. 

namespace LevDan.Exif
{
    public sealed class ExifTag
    {
        private int _id;
        private string _description;
        private string _fieldName;
        private string _value;

        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                this._value = value;
            }
        }

        public ExifTag(int id, string fieldName, string description)
        {
            this._id = id;
            this._description = description;
            this._fieldName = fieldName;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}-{2}) = {3}", Description, Id, FieldName, Value);
        }

    }
}
