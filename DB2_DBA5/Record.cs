using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB2_DBA5
{
    class Record
    {

        public string one,
        two,
            three,
            four,
            five,
            six,
            seven,
            eight;
        public int row;

        public Record(string one, string two, string three, string four, string five, string six, string seven, string eight, int row)
        {
            this.one = one;
            this.two = two;
            this.three = three;
            this.four = four;
            this.five = five;
            this.six = six;
            this.seven = seven;
            this.eight = eight;
            this.row = row;
        }
       
    }

    class RecordComparer : IEqualityComparer<Record>
    {

        public bool Equals(Record x, Record y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            return x.one == y.one && x.two == y.two && x.three == y.three && x.four == y.four && x.five == y.five &&
                x.six == y.six && x.seven == y.seven && x.eight == y.eight;
        }

        public int GetHashCode(Record record)
        {

            if (record is null) return 0;
            unchecked
            {
                int preComputeHash(int hashedRecord)
                {
                    var hashCode = 13;
                    hashCode = (hashCode * 397) ^ hashedRecord;
                    return hashCode;
                }
                int hash_one = record.one == null ? 0 : preComputeHash(record.one.GetHashCode());
                int hash_two = record.two == null ? 0 : preComputeHash(record.two.GetHashCode());
                int hash_three = record.three == null ? 0 : preComputeHash(record.three.GetHashCode());
                int hash_four = record.four == null ? 0 : preComputeHash(record.four.GetHashCode());
                int hash_five = record.five == null ? 0 : preComputeHash(record.five.GetHashCode());
                int hash_six = record.six == null ? 0 : preComputeHash(record.six.GetHashCode());
                int hash_seven = record.seven == null ? 0 : preComputeHash(record.seven.GetHashCode());
                int hash_eight = record.eight == null ? 0 : preComputeHash(record.eight.GetHashCode());
                return hash_one ^ hash_two ^ hash_three ^ hash_four ^ hash_five ^ hash_six ^ hash_seven ^ hash_eight;
            }
        }
    }
}
