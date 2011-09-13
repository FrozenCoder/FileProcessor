using System.Collections.Generic;
using Framework.TRH.Data;
using Framework.TRH.ErrorHandling.CustomErrors;
using NHibernate;
using NHibernate.Criterion;

namespace FileProcessor.DataLayer.FluentMappings.Repositories
{
    public class BaseReadRepository<T>:IReadRepository<T>
    {
        protected ICriteria criteria;
        protected readonly ISessionProvider sessionProvider;

        public BaseReadRepository(ISessionProvider printingSessionProvider)
        {
            sessionProvider = printingSessionProvider;
        }

        public IList<T> GetAll(bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.Eq("Active", true));
            return criteria.List<T>();
        }

        public IList<T> GetAll(string orderingColumn, bool ascending, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.AddOrder(new Order(orderingColumn, ascending));
            criteria.Add(Restrictions.Eq("Active", true));
            return criteria.List<T>();
        }

        public T GetByUniqueId(string idColumnName, object value, bool refreshSession)
        {
            try
            {
                SetSessionForCriteria(refreshSession);
                criteria.Add(Restrictions.Eq(idColumnName, value));
                criteria.Add(Restrictions.Eq("Active", true));
                return (T)criteria.UniqueResult();
            }
            catch (NonUniqueResultException)
            {
                throw new DataCorruptionError("NonUniqueResultException caught: Searching for " + idColumnName + " value of " + value + " returned more than one result");
            }

        }

        public IList<T> GetBySingleColumnMatch(string column, object value, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.Eq(column, value));
            criteria.Add(Restrictions.Eq("Active", true));

            return criteria.List<T>();
        }

        public IList<T> GetBySingleColumnMatch(string column, object value, string orderingColumn, bool ascending, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.Eq(column, value));
            criteria.AddOrder(new Order(orderingColumn, ascending));
            criteria.Add(Restrictions.Eq("Active", true));
            return criteria.List<T>();
        }

        public IList<T> GetByMultiColumnMatch(string[] columns, object[] values, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);

            for (int i = 0; i < columns.Length; i++)
            {
                criteria.Add(Restrictions.Eq(columns[i], values[i]));
                criteria.Add(Restrictions.Eq("Active", true));
            }

            return criteria.List<T>();
        }

        public IList<T> GetByMultiColumnMatch(string[] columns, object[] values, string[] orderingColumns, bool ascending, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);

            for (int i = 0; i < columns.Length; i++)
            {
                criteria.Add(Restrictions.Eq(columns[i], values[i]));
                criteria.Add(Restrictions.Eq("Active", true));

                if (i <= orderingColumns.Length - 1)
                {
                    criteria.AddOrder(new Order(orderingColumns[i], ascending));
                }

            }

            return criteria.List<T>();
        }

        public IList<T> GetStartsWith(string columnName, string value, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.InsensitiveLike(columnName, value, MatchMode.Start));
            criteria.Add(Restrictions.Eq("Active", true));
            return criteria.List<T>();
        }

        public IList<T> GetStartsWith(string columnName, string value, string orderingColumn, bool ascending, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.InsensitiveLike(columnName, value, MatchMode.Start));
            criteria.Add(Restrictions.Eq("Active", true));
            criteria.AddOrder(new Order(orderingColumn, ascending));
            return criteria.List<T>();
        }

        public IList<T> GetEndsWith(string columnName, string value, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.InsensitiveLike(columnName, value, MatchMode.End));
            criteria.Add(Restrictions.Eq("Active", true));
            return criteria.List<T>();
        }

        public IList<T> GetEndsWith(string columnName, string value, string orderingColumn, bool ascending, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.InsensitiveLike(columnName, value, MatchMode.End));
            criteria.Add(Restrictions.Eq("Active", true));
            criteria.AddOrder(new Order(orderingColumn, ascending));
            return criteria.List<T>();
        }

        public IList<T> GetContains(string columnName, string value, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.InsensitiveLike(columnName, value, MatchMode.Anywhere));
            criteria.Add(Restrictions.Eq("Active", true));
            return criteria.List<T>();
        }

        public IList<T> GetContains(string columnName, string value, string orderingColumn, bool ascending, bool refreshSession)
        {
            SetSessionForCriteria(refreshSession);
            criteria.Add(Restrictions.InsensitiveLike(columnName, value, MatchMode.Anywhere));
            criteria.Add(Restrictions.Eq("Active", true));
            criteria.AddOrder(new Order(orderingColumn, ascending));
            return criteria.List<T>();
        }

        private void SetSessionForCriteria(bool refreshSession)
        {
            criteria = refreshSession ? sessionProvider.GetNewSession().CreateCriteria(typeof(T)) : sessionProvider.GetCurrentSession().CreateCriteria(typeof(T));
        }
    }
}