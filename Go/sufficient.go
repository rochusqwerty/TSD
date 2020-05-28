package main

import (
	"sort"
	"strings"
)

//feel free to define additional functions as needed

func palindrome(str string) bool {
	for i := 0; i < len(str)/2; i++ {
		if str[i] != str[len(str)-i-1] {
			return false
		}
	}
	return true
}

func wordcount(str string) string {
	max := 0
	words := strings.Split(str, " ")
	wordCountMap := make(map[string]int)

	for tmp := range words {
		wordCountMap[words[tmp]]++
	}

	for _, v := range wordCountMap {
		if v > max {
			max = v
		}
	}

	wordsMax := make([]string, 0, len(wordCountMap))
	for k, v := range wordCountMap {
		if v == max {
			wordsMax = append(wordsMax, k)
		}
	}
	sort.Strings(wordsMax)
	return wordsMax[0]
}

func rotate(numbers []int) []int {
	var result []int
	length := numbers[0] % len(numbers)

	for i := length; i < len(numbers); i++ {
		result = append(result, numbers[i])
	}
	for i := 0; i < length; i++ {
		result = append(result, numbers[i])
	}
	return result
}

func fib(nums []int) int {
	sum := 0
	for _, num := range nums {
		sum += fibonacci(num)
	}
	return sum
}

func fibonacci(n int) int {
	if n <= 1 {
		return n
	}
	return fibonacci(n-1) + fibonacci(n-2)
}

func main() {
	performTests()
}
