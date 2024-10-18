using SILF.Script;
using SILF.Script.Elements;
using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Runtime;

namespace LIN.Inventory.Realtime.Script;

public class SILFFunction(Action<List<ParameterValue>> action) : IFunction
{
    public Tipo? Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Parameter> Parameters { get; set; } = [];
    public Context Context { get; set; } = null!;

    private readonly Action<List<ParameterValue>> Action = action;

    public FuncContext Run(Instance instance, List<ParameterValue> values, ObjectContext @object)
    {
        Action.Invoke(values);
        return new();
    }

}