using System;
using System.Data;

namespace MyCSharpDotNet.AdoDotNetApplication
{
    // Example of an enhanced SqlDataReader class.
    // It extends the standard SqlDataReader functionality by the following:
    //     - GetXYZ methods can specify a column name
    //     - GetNullableXYZ methods to get nullable types
    //     - GetString returns null for null data (not String.empty)
    public class EnhancedSqlDataReader : IDataReader
    {
        private IDataReader dataReader;

        #region Constructor

        public EnhancedSqlDataReader(IDataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        #endregion

        #region Nullable types

        public DateTime? GetNullableDateTime(string name)
        {
            return GetNullableDateTime(this.dataReader.GetOrdinal(name));
        }

        public DateTime? GetNullableDateTime(int index)
        {
            if (this.dataReader.IsDBNull(index))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetDateTime(index);
            }
        }

        public Guid? GetNullableGuid(string name)
        {
            return GetNullableGuid(this.dataReader.GetOrdinal(name));
        }

        public Guid? GetNullableGuid(int index)
        {
            if (this.dataReader.IsDBNull(index))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetGuid(index);
            }
        }

        public decimal? GetNullableDecimal(string name)
        {
            return GetNullableDecimal(this.dataReader.GetOrdinal(name));
        }

        public decimal? GetNullableDecimal(int index)
        {
            if (this.dataReader.IsDBNull(index))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetDecimal(index);
            }
        }

        public int? GetNullableInt32(string name)
        {
            return GetNullableInt32(this.dataReader.GetOrdinal(name));
        }

        public int? GetNullableInt32(int index)
        {
            if (this.dataReader.IsDBNull(index))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetInt32(index);
            }
        }

        public bool? GetNullableBoolean(string name)
        {
            return GetNullableBoolean(this.dataReader.GetOrdinal(name));
        }

        public bool? GetNullableBoolean(int index)
        {
            if (this.dataReader.IsDBNull(index))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetBoolean(index);
            }
        }

        #endregion

        #region Delegations of Get<DataType> methods to the standard DataReader

        public string GetString(string name)
        {
            return GetString(this.dataReader.GetOrdinal(name));
        }

        public string GetString(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetString(i).Trim();
            }
        }

        public object GetValue(string name)
        {
            return GetValue(this.dataReader.GetOrdinal(name));
        }

        public object GetValue(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return this.dataReader.GetValue(i);
            }
        }

        public int GetInt32(string name)
        {
            return GetInt32(this.dataReader.GetOrdinal(name));
        }

        public int GetInt32(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetInt32(i);
            }
        }

        public double GetDouble(string name)
        {
            return GetDouble(this.dataReader.GetOrdinal(name));
        }

        public double GetDouble(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetDouble(i);
            }
        }

        public System.Guid GetGuid(string name)
        {
            return GetGuid(this.dataReader.GetOrdinal(name));
        }

        public System.Guid GetGuid(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return Guid.Empty;
            }
            else
            {
                return this.dataReader.GetGuid(i);
            }
        }

        public bool GetBoolean(string name)
        {
            return GetBoolean(this.dataReader.GetOrdinal(name));
        }

        public bool GetBoolean(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return false;
            }
            else
            {
                return this.dataReader.GetBoolean(i);
            }
        }

        public byte GetByte(string name)
        {
            return GetByte(this.dataReader.GetOrdinal(name));
        }

        public byte GetByte(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetByte(i);
            }
        }

        public Int64 GetBytes(string name, Int64 fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            return GetBytes(this.dataReader.GetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
        }

        public Int64 GetBytes(int i, Int64 fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetBytes(i, fieldOffset, buffer, bufferOffset, length);
            }
        }

        public char GetChar(string name)
        {
            return GetChar(this.dataReader.GetOrdinal(name));
        }

        public char GetChar(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return char.MinValue;
            }
            else
            {
                char[] myChar = new char[1];
                this.dataReader.GetChars(i, 0, myChar, 0, 1);
                return myChar[0];
            }
        }

        public Int64 GetChars(string name, Int64 fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            return GetChars(this.dataReader.GetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
        }

        public Int64 GetChars(int i, Int64 fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetChars(i, fieldOffset, buffer, bufferOffset, length);
            }
        }

        public DateTime GetDateTime(string name)
        {
            return GetDateTime(this.dataReader.GetOrdinal(name));
        }

        public DateTime GetDateTime(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return DateTime.MinValue;
            }
            else
            {
                return this.dataReader.GetDateTime(i);
            }
        }

        public decimal GetDecimal(string name)
        {
            return GetDecimal(this.dataReader.GetOrdinal(name));
        }

        public decimal GetDecimal(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetDecimal(i);
            }
        }

        public float GetFloat(string name)
        {
            return GetFloat(this.dataReader.GetOrdinal(name));
        }

        public float GetFloat(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetFloat(i);
            }
        }

        public short GetInt16(string name)
        {
            return GetInt16(this.dataReader.GetOrdinal(name));
        }

        public short GetInt16(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetInt16(i);
            }
        }

        public Int64 GetInt64(string name)
        {
            return GetInt64(this.dataReader.GetOrdinal(name));
        }

        public Int64 GetInt64(int i)
        {
            if (this.dataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return this.dataReader.GetInt64(i);
            }
        }

        #endregion

        #region Delegations of other methods to the standard DataReader

        public IDataReader GetData(string name)
        {
            return GetData(this.dataReader.GetOrdinal(name));
        }

        public IDataReader GetData(int i)
        {
            return this.dataReader.GetData(i);
        }

        public Type GetFieldType(string name)
        {
            return GetFieldType(this.dataReader.GetOrdinal(name));
        }

        public Type GetFieldType(int i)
        {
            return this.dataReader.GetFieldType(i);
        }

        public string GetDataTypeName(string name)
        {
            return GetDataTypeName(this.dataReader.GetOrdinal(name));
        }

        public string GetDataTypeName(int i)
        {
            return this.dataReader.GetDataTypeName(i);
        }

        public string GetName(int i)
        {
            return this.dataReader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return this.dataReader.GetOrdinal(name);
        }

        public DataTable GetSchemaTable()
        {
            return this.dataReader.GetSchemaTable();
        }

        public int GetValues(object[] values)
        {
            return this.dataReader.GetValues(values);
        }

        public bool IsClosed
        {
            get
            {
                return this.dataReader.IsClosed;
            }
        }

        public bool IsDBNull(string name)
        {
            return IsDBNull(this.dataReader.GetOrdinal(name));
        }

        public bool IsDBNull(int i)
        {
            return this.dataReader.IsDBNull(i);
        }

        public object this[string name]
        {
            get
            {
                object val = this.dataReader[name];

                if (DBNull.Value.Equals(val))
                {
                    return null;
                }
                else
                {
                    return val;
                }
            }
        }

        public object this[int i]
        {
            get
            {
                if (this.dataReader.IsDBNull(i))
                {
                    return null;
                }
                else
                {
                    return this.dataReader[i];
                }
            }
        }

        public bool Read()
        {
            return this.dataReader.Read();
        }

        public bool NextResult()
        {
            return this.dataReader.NextResult();
        }

        public void Close()
        {
            this.dataReader.Close();
        }

        public int Depth
        {
            get
            {
                return this.dataReader.Depth;
            }
        }

        public int FieldCount
        {
            get
            {
                return this.dataReader.FieldCount;
            }
        }

        public int RecordsAffected
        {
            get
            {
                return this.dataReader.RecordsAffected;
            }
        }

        #endregion

        #region IDisposable

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.dataReader.Dispose();
            }

            this.disposed = true;
        }

        ~EnhancedSqlDataReader()
        {
            Dispose(false);
        }

        #endregion
    }
}