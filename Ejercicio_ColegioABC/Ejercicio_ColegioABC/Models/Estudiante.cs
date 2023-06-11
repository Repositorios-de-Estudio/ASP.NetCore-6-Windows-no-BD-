using System;
using System.Collections.Generic;

namespace Ejercicio_ColegioABC.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public short Edad { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual ICollection<Materia> Idmateria { get; } = new List<Materia>();
}
