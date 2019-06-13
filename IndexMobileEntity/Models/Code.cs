using IndexMobileEntity.Models.BaseClasses;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель телефонного кода
	/// </summary>
	public class Code  : BaseClassWithTitle<Code>
	{
		/// <summary>
		/// Телефонный код
		/// </summary>
		public int Title { get; set; }

		/// <summary>
		/// Телефонный код
		/// </summary>
		public Code()
		{

		}
	}
}
