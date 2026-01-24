class Company < ApplicationRecord
  has_many :offers, dependent: :destroy

  validates :name, presence: true
  validates :tax_number, presence: true, uniqueness: true
end
