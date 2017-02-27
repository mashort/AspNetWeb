using System;
using System.Data.SqlClient;
using FeatureToggle.Core;

namespace FeatureControl
{
    public class CustomFeatureToggleProviders
    {
        public class CustomSqlFeatureToggleProvider : IBooleanToggleValueProvider
        {
            private string FeatureFlagName { get; set; }

            public CustomSqlFeatureToggleProvider(string featureFlagName)
            {
                FeatureFlagName = featureFlagName;
            }

            public bool EvaluateBooleanToggleValue(IFeatureToggle toggle)
            {
                return GetFeatureFlagValue();
            }

            private bool GetFeatureFlagValue()
            {
                bool retVal = false;
                string connectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=MyRnD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                string query = String.Format(
                "SELECT f.FeatureFlagEnabled FROM dbo.FeatureFlags f where f.FeatureFlagName = '{0}'",
                FeatureFlagName);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                retVal = rdr.GetBoolean(0);
                            }
                        }
                    }
                }

                return retVal;
            }
        }
    }
}
