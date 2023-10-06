module Main where

letters :: String 
letters = "MDCLXVI"

roman :: String  -> Int 
roman "" = 0
roman s = 10^(value `div` 2)*(value `mod`2*4+1) - roman(fst split_list) + roman(snd split_list)
    where
        (split_list,value) = head [(splitByOne s letter,6-index) | (index,letter) <- zip [0..] letters, letter `elem` s ]
        

splitByOne :: String -> Char -> ([Char],[Char])
splitByOne s letter = (left,right)
    where
        (left,(x:right)) = splitAt i s 
        i = head [x | (x,y) <- zip [0..] s, y == letter]


main = do
print $ roman "MMXIV"