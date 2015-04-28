Console.WriteLine("Frosh Fish <O|<");
Console.WriteLine("");

Console.WriteLine("Pick a payload:");
var payloads = GetPayloads().ToArray();
var option = SelectOption(payloads, x => x);





IEnumerable<string> GetPayloads() {
	yield return "thing 1";
	yield return "thing 2";
}

void WriteOptions<T>(T[] things, Func<T, string> getDescription) {
	foreach (var x in things.Select((a, i) => new { Index = i + 1, Thing = a })) {
		Console.WriteLine("[{0}] {1}", x.Index, getDescription(x.Thing));
	}
}

T SelectOption<T>(T[] things, Func<T, string> getDescription) {
	WriteOptions(things, getDescription);
	Console.Write(": ");
	var input = Console.ReadLine();
	int i;
	var valid = int.TryParse(input, out i) && i - 1 < things.Length;
	if (!valid) {
		Console.WriteLine("Invalid selection");
		return SelectOption(things, getDescription);
	}
	return things[i - 1];
}