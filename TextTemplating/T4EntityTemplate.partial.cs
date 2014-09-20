using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
	public partial class T4EntityTemplate
	{

		public T4EntityTemplate(T4EntityContext context)
		{
			this._context = context;
		}

	    protected T4EntityContext Context
	    {
	        get { return this._context; }
	    }

	    private readonly T4EntityContext _context;
	}

	public class T4Template<TContext>
	{
	}
}