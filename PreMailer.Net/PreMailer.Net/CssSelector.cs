using System;
using System.Text.RegularExpressions;

namespace PreMailer.Net
{
	public class CssSelector
	{
    private static TimeSpan RegexTimespan = new TimeSpan(0, 3, 0);
    protected static Regex NotMatcher = new Regex(@":not\((.+)\)", RegexOptions.IgnoreCase | RegexOptions.Compiled, RegexTimespan);

		public string Selector { get; protected set; }

		public bool HasNotPseudoClass
		{
			get
			{
				return NotMatcher.IsMatch(Selector);
			}
		}
		
		public string NotPseudoClassContent
		{
			get
			{
				var match = NotMatcher.Match(Selector);
				return match.Success ? match.Groups[1].Value : null;
			}
		}

		public CssSelector(string selector)
		{
			Selector = selector;
		}

		public CssSelector StripNotPseudoClassContent()
		{
			var stripped = NotMatcher.Replace(Selector, string.Empty);
			return new CssSelector(stripped);
		}

		public override string ToString()
		{
			return Selector;
		}
	}
}