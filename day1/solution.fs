namespace Day01

open System.IO

module Part1 =
    let run () =
        let inputFilePath = Path.Combine(__SOURCE_DIRECTORY__, "input.txt")
        let perElfInputData = File.ReadAllText(inputFilePath).Split("\n\n");

        let caloriesPerElves =
            Array.map (fun (line: string) ->
                line.Split("\n")
                |> Array.map int
                |> Array.sum
            ) perElfInputData

        Array.max caloriesPerElves