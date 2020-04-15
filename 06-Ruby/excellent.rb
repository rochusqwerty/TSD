class Clock
  attr_reader :hours, :minutes, :seconds

  def initialize(hours, minutes, seconds)
    self.instance_variable_set(:@hours, hours)
    self.instance_variable_set(:@minutes, minutes)
    self.instance_variable_set(:@seconds, seconds)
  end

  def +(min)
    tmp_min = (minutes + min) % 60
    self.instance_variable_set(:@minutes, tmp_min)
    tmp_hou = (hours + ((minutes + min) / 60) - 1) % 24
    self.instance_variable_set(:@hours, tmp_hou)
    Clock.new(hours,minutes,seconds)
  end

  def -(min)
    tmp_min = (minutes - min) % 60
    self.instance_variable_set(:@minutes, tmp_min)
    tmp_hou = (hours + ((minutes - min) / 60) - 1) % 24
    self.instance_variable_set(:@hours, tmp_hou)
    Clock.new(hours,minutes,seconds)
  end

  def print()
    puts("#{hours}:#{minutes}:#{seconds}")
  end

  def ==(otherclk)
    if @hours == otherclk.hours && @minutes == otherclk.minutes && @seconds == otherclk.seconds
        return true 
    else 
      return false 
    end
  end
end