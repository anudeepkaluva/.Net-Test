# LargestWord
	This is a console application to find the LargestWord constructed by concatenating short words.

## ReadWordFile
	The ReadWordFile method reads the text file and stores the words in the text file in to a string array.

## FindLongestWords
##### Parameters : listOfWords which accepts string[]
	The method FindLongestWords accepts a string[] array parameter.then sort the array by string length in descending order.
	Create a HashSet for the string array.
	Iterate the string array in a loop and check with the method(isMadeOfWords) to find the if the string largest word. if it is true, it will 
	return the word and exit the method.
	
## isMadeOfWords
#### Parameters 
	- word : (Item that is iterated in FindLongestWords method)
	- word : (HashSet is the HashSet passed from FindLongestWords method)
#
	The method accepts two parameters, word and HashSet.This method in turn calls another method (generatePairs) to create possible combinations for a string
	and compare the combinations with dictionary and return the word which is concatenated by short words.
	
## generatePairs	
	The method returns the possible combinations of a string based on the input parameter word.

## isMadeOfWordsCount
	This method accepts the string array and return the total count of how many of the words in the list can be constructed with other
