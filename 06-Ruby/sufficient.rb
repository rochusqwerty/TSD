#task1
class Integer 
  def task1
    (1..self).inject { |mul, n| mul * n } 
  end 
end
puts(4.task1)

#task2
class Integer 
  def task2
    if self > 0
     (0..self).inject { |sum, n| sum + n } 
    else
      raise RuntimeError, "RuntimeError: cannot count factorial for number less than 1"
    end 
  end
end
puts(4.task2)

#taks3
module InstanceModule
  def square
    self * self
  end
end

class Integer
  include InstanceModule
end
puts(4.square)

#task4
module ClassModule
  def sample(size)
    if (size < 0)
      raise ArgumentError, 'ArgumentError: the number must be positive'
    end
    (0..1000).to_a.sample(size)
  end
end

class Integer
  extend ClassModule
end
Integer.sample(4)