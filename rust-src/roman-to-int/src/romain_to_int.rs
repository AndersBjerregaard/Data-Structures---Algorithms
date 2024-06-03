/*
	Constraints:
	1 <= s.length <= 15
	s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
	It is guaranteed that s is a valid roman numeral in the range [1, 3999].
	Symbols:
	I             1
	V             5
	X             10
	L             50
	C             100
	D             500
	M             1000
*/
pub mod romain_to_int {
    use std::collections::HashMap;

    lazy_static! {
        static ref ROMAN_LETTERS: HashMap<&'static str, i32> = {
        let mut m = HashMap::new();
            m.insert("I", 1);
            m.insert("V", 5);
            m.insert("X", 10);
            m.insert("L", 50);
            m.insert("C", 100);
            m.insert("D", 500);
            m.insert("M", 1000);
        };
    }

    pub fn romain_to_int(x: &str) -> u32 {
        unimplemented!()
    }
}

#[cfg(test)]
mod tests {
    use crate::romain_to_int::romain_to_int::romain_to_int;
    #[test]
    fn test1() {
		assert_eq!(3, romain_to_int("III"))
    }
    #[test]
    fn test2() {
        assert_eq!(58, romain_to_int("LVIII"))
    }
    #[test]
    fn test3() {
        assert_eq!(1994, romain_to_int("MCMXCIV"))
    }
}
