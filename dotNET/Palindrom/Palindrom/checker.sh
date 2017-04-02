file="palindroms.txt"
#cp Program.cs AutoProgram.cs
#sed -i .bk 's/Console.ReadLine().ToLowerInvariant()/args.First().ToLowerInvariant()/g' AutoProgram.cs
#rm AutoProgram.cs.bk
#mcs AutoProgram.cs
mcs AutoProgram.cs
while IFS= read -r line
do
	mono AutoProgram.exe "$line"
done <"$file"