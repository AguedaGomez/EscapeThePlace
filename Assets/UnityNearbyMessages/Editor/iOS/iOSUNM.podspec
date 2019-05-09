#
# Be sure to run `pod lib lint iOSUNM.podspec' to ensure this is a
# valid spec before submitting.
#
# Any lines starting with a # are optional, but their use is encouraged
# To learn more about a Podspec see https://guides.cocoapods.org/syntax/podspec.html
#

Pod::Spec.new do |s|
  s.name             = 'iOSUNM'
  s.version          = '0.1.0'
  s.summary          = 'A short description of iOSUNM.'

# This description is used to generate tags and improve search results.
#   * Think: What does it do? Why did you write it? What is the focus?
#   * Try to keep it short, snappy and to the point.
#   * Write the description between the DESC delimiters below.
#   * Finally, don't worry about the indent, CocoaPods strips it!

  s.description      = <<-DESC
TODO: Add long description of the pod here.
                       DESC

  s.homepage         = 'https://github.com/agonper/iOSUNM'
  # s.screenshots     = 'www.example.com/screenshots_1', 'www.example.com/screenshots_2'
  s.license          = { :type => 'MIT', :file => 'LICENSE' }
  s.author           = { 'agonper' => 'algonzal@uji.es' }
  s.source           = { :git => 'https://github.com/agonper/iOSUNM.git', :tag => s.version.to_s }
  # s.social_media_url = 'https://twitter.com/<TWITTER_USERNAME>'

  s.static_framework = true
  s.ios.deployment_target = '8.0'

  s.source_files = 'iOSUNM/Classes/**/*.{h,m,mm}'
  
  # s.resource_bundles = {
  #   'iOSUNM' => ['iOSUNM/Assets/*.png']
  # }
  # s.frameworks = 'UIKit', 'MapKit'
  # s.dependency 'AFNetworking', '~> 2.3'
  s.ios.dependency 'NearbyMessages', '~> 1.1.1'
end
