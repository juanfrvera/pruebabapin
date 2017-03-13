namespace Microsoft.Practices.EnterpriseLibrary.Security
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Security.Properties;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Security.Principal;
    using System.Text;

    [ConfigurationElementType(typeof(DbAuthorizationRuleProviderData))]
    public class DbAuthorizationRuleProvider : AuthorizationProvider
    {
        private IDictionary<string, IAuthorizationRule> authorizationRules;
        private Database db;

        public DbAuthorizationRuleProvider()
        {
        }

        public DbAuthorizationRuleProvider(Database db, IDictionary<string, IAuthorizationRule> authorizationRules)
        {
            if (authorizationRules == null)
            {
                throw new ArgumentNullException("authorizationRules");
            }
            this.db = db;
            this.authorizationRules = authorizationRules;
        }

        public override bool Authorize(IPrincipal principal, string ruleName)
        {
            if (principal == null)
            {
                throw new ArgumentNullException("principal");
            }
            if ((ruleName == null) || (ruleName.Length == 0))
            {
                throw new ArgumentNullException("ruleName");
            }
            BooleanExpression parsedExpression = this.GetParsedExpression(ruleName);
            if (parsedExpression == null)
            {
                throw new InvalidOperationException(string.Format(Resources.AuthorizationRuleNotFoundMsg, ruleName));
            }
            bool flag = parsedExpression.Evaluate(principal);
            base.get_InstrumentationProvider().FireAuthorizationCheckPerformed(principal.Identity.Name, ruleName);
            if (!flag)
            {
                base.get_InstrumentationProvider().FireAuthorizationCheckFailed(principal.Identity.Name, ruleName);
            }
            return flag;
        }

        private BooleanExpression GetParsedExpression(string ruleName)
        {
            IAuthorizationRule rule = null;
            this.authorizationRules.TryGetValue(ruleName, out rule);
            if (rule == null)
            {
                return null;
            }
            string str = rule.get_Expression();
            Parser parser = new Parser();
            return parser.Parse(str);
        }

        public void ModifyExpression(string rulenName, string expression)
        {
            DBAuthorizationRuleData data = (DBAuthorizationRuleData) this.authorizationRules[rulenName];
            string str = "aspnet_Rules_ModifyExpression";
            DbCommand storedProcCommand = this.db.GetStoredProcCommand(str);
            DbParameter parameter = storedProcCommand.CreateParameter();
            parameter.ParameterName = "@ruleID";
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = data.Id;
            storedProcCommand.Parameters.Add(parameter);
            parameter = storedProcCommand.CreateParameter();
            parameter.ParameterName = "@Expression";
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = expression;
            storedProcCommand.Parameters.Add(parameter);
            this.db.ExecuteNonQuery(storedProcCommand);
            data.Expression = expression;
        }

        public string RuleExpressionModify(string ruleExpression, TokenType tokenType, string name, bool include, bool exclude)
        {
            if (include && exclude)
            {
                throw new Exception("no puede incluir y excluir al mismo tiempo");
            }
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = true;
            TokenType type = 0;
            StringBuilder builder = new StringBuilder();
            LexicalAnalyzer analyzer = new LexicalAnalyzer(ruleExpression);
            for (TokenType type2 = analyzer.MoveNext(); type2 != 12; type2 = analyzer.MoveNext())
            {
                string str = analyzer.get_Current();
                if (flag4)
                {
                    if (type2 == 10)
                    {
                        if (!(!include || flag2))
                        {
                            str = (flag ? "or " : "") + ((tokenType == 4) ? "R" : "I") + ":" + name + str;
                        }
                        else if (!(include || flag))
                        {
                            str = "i:*" + str;
                        }
                        flag4 = false;
                    }
                    else if (type2 == 1)
                    {
                        str = "";
                    }
                    else if ((type2 == 4) || (type2 == 3))
                    {
                        str = "";
                        type = type2;
                    }
                    else if (type2 == 6)
                    {
                        str = (flag ? "or " : "") + ((type == 4) ? "R" : "I") + ":" + analyzer.get_Current();
                        if ((type == tokenType) && (analyzer.get_Current() == name))
                        {
                            flag2 = true;
                            if (!include)
                            {
                                str = "";
                            }
                        }
                        if (!flag)
                        {
                            flag = str != "";
                        }
                    }
                    else if (type2 == 7)
                    {
                        str = "";
                    }
                }
                else
                {
                    str = "";
                    if ((type2 == 4) || (type2 == 3))
                    {
                        type = type2;
                    }
                    else if (((type2 == 6) || (type2 == 7)) || (type2 == 8))
                    {
                        str = "and not " + ((type == 4) ? "R" : "I") + ":" + analyzer.get_Current();
                        if ((type == tokenType) && (analyzer.get_Current() == name))
                        {
                            flag3 = true;
                            if (!exclude)
                            {
                                str = "";
                            }
                        }
                        if (!flag)
                        {
                            flag = str != "";
                        }
                    }
                }
                if (str != "")
                {
                    builder.Append(str + " ");
                }
            }
            if (!(!exclude || flag3))
            {
                builder.Append("and not " + ((tokenType == 4) ? "R" : "I") + ":" + name);
            }
            ruleExpression = builder.ToString();
            return ruleExpression;
        }

        public IDictionary<string, IAuthorizationRule> AuthorizationRules
        {
            get
            {
                return this.authorizationRules;
            }
            set
            {
                this.authorizationRules = value;
            }
        }
    }
}

