using System.Text;

namespace Infrastructure.Repositories
{
    internal sealed class QueryBuilder
    {
        private readonly StringBuilder _query;

        public QueryBuilder()
        {
            _query = new StringBuilder();
        }

        public QueryBuilder Select(params string[] columns)
        {
            _query.Append("SELECT ").AppendJoin(",", columns);
            return this;
        }

        public QueryBuilder From(string table)
        {
            _query.Append(" FROM ").Append(table);
            return this;
        }

        public QueryBuilder Where(string condition)
        {
            _query.Append(" WHERE ").Append(condition);
            return this;
        }

        public QueryBuilder And(string condition)
        {
            _query.Append(" AND ").Append(condition);
            return this;
        }

        public QueryBuilder Or(string condition)
        {
            _query.Append(" OR ").Append(condition);
            return this;
        }

        public QueryBuilder OrderBy(string column)
        {
            _query.Append(" ORDER BY ").Append(column);
            return this;
        }

        public QueryBuilder Ascending()
        {
            _query.Append(" ASC");
            return this;
        }

        public QueryBuilder Descending()
        {
            _query.Append(" DESC");
            return this;
        }

        internal QueryBuilder Delete()
        {
            _query.Append("DELETE ");
            return this;
        }

        internal QueryBuilder InsertInto(string table, params string[] columns)
        {
            _query.Append("INSERT INTO ").Append(table);
            if (columns.Length > 0)
                _query.Append(" (").AppendJoin(",", columns).Append(')');
            return this;
        }

        internal QueryBuilder Values(params string[] values)
        {
            _query.Append(" VALUES (").AppendJoin(",", values).Append(')');
            return this;
        }

        internal QueryBuilder Update(string table)
        {
            _query.Append("UPDATE ").Append(table);
            return this;
        }

        internal QueryBuilder Set(params string[] values)
        {
            _query.Append(" SET ").AppendJoin(",", values);
            return this;
        }

        public string Build() => _query.ToString();
    }
}
