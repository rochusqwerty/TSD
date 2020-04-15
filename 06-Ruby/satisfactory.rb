#task1
def min_max(array)
  result = array.inject { |sum, n| sum + n }
  min = result
  max = 0
  array.each do |item|
    if result - item < min
      min = result - item
    end
    if result - item > max
      max = result - item
    end
  end
  puts "#{min} #{max}"
end
#min_max([1, 2, 3, 4, 5])
#min_max([2, 8, 3, 5, 1])

#task2 
def decimal(binary_num)
  num = 1
  result = 0
  binary_num.chars.reverse.each do |item|
    if (item != "1") && (item != "0")
      raise ArgumentError, 'ArgumentError: this is not a binary number'
    end
    result += item.to_i * num
    num *= 2
  end
  result
end
#decimal("1101")

#task3
def count_words(phrase)
  words = phrase.split
  hash = Hash.new
  words.each do |w|
    if hash.has_key?(w)
      hash[w] = h[w] + 1
    else
      hash[w] = 1
    end
  end
  hash
end
#count_words("olly olly come here free")
