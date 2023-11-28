namespace Day03

open System.IO

module private InternalModule =
    let scoreCharacter (character: char) =
        match character with
        | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 1
        | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 27
        | _ -> failwith "Unexpected character"

module Part1 =
    let getDuplicatedCharacters (line: string) =
        let middleIndex = line.Length / 2

        let part1 = List.ofSeq line.[0..middleIndex-1]
        let part2 = List.ofSeq line.[middleIndex..]

        let commonCharacters =
            Set.intersect (Set.ofList(part1)) (Set.ofList(part2))

        match Set.toList commonCharacters with
        | [] -> None
        | [commonChar] -> Some commonChar
        | _ -> failwith "More than one duplicated characters"

    let run () =
        let data = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "input.txt"))
        let duplicatedCharacters = data |> Array.map getDuplicatedCharacters |> Array.choose id
        let scoresArray = duplicatedCharacters |> Array.map InternalModule.scoreCharacter
        scoresArray |> Array.sum

module Part2 =
    let intersectionOfThreeSets (set1: Set<char>) (set2: Set<char>) (set3: Set<char>) =
        set1
        |> Set.intersect set2
        |> Set.intersect set3
        |> Set.minElement

    let getSharedCharacter (lines: string array) =
        let line1 = lines.[0] |> Seq.toList |> Set.ofList
        let line2 = lines.[1] |> Seq.toList |> Set.ofList
        let line3 = lines.[2] |> Seq.toList |> Set.ofList

        intersectionOfThreeSets line1 line2 line3

    let run () =
        let data = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "input.txt")) |> Array.chunkBySize 3
        data |> Array.map getSharedCharacter |> Array.map InternalModule.scoreCharacter |> Array.sum