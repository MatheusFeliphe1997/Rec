namespace RecMatheus.Models;
public class Imc
{
    public int Id { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }
    public double? Valor { get; set; }

    public int AlunoId { get; set; }
    public Aluno? Aluno { get; set; }


}