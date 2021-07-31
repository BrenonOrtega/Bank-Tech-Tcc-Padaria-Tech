using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadariaTech.Domain.Models
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class EntityBase : IEntityBase<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
    }
}