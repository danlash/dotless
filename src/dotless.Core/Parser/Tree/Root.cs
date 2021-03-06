namespace dotless.Core.Parser.Tree
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Infrastructure;
    using Infrastructure.Nodes;

    public class Root : Ruleset
    {
        public Func<ParsingException, ParserException> Error { get; set; }

        public Root(List<Node> rules, Func<ParsingException, ParserException> error) :base(new NodeList<Selector>(), rules)
        {
            Error = error;
        }

        public override string ToCSS(Env env)
        {
            try
            {
                return base.ToCSS(env);
            }
            catch (ParsingException e)
            {
                throw Error(e);
            }
        }

    }
}