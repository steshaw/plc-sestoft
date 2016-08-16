Generating and compiling the micro-SQL lexer and parser (Usql/README.TXT)
-------------------------------------------------------------------------

To generate the micro-SQL lexer and parser, and load both into an
interactive F# session, do this from a command prompt:

   fslex --unicode UsqlLex.fsl
   fsyacc --module UsqlPar UsqlPar.fsy
   fsi -r FSharp.PowerPack.dll Absyn.fs UsqlPar.fs UsqlLex.fs Parse.fs

Now you can exercise the lexer and parser from within the F# session:

   open Parse;;
   fromString "SELECT Employee.name, salary * (1 - taxrate) FROM Employee";;

   #q;;
