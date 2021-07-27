using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Models.Base
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }

        string Name { get; set; }
    }

    public abstract class EntityBase : IEntityBase<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [MaxLength(150)]
        public string Name { get ; set; }
    }
}